using System;
using System.Text;
using System.Collections.Generic;

using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using System.IO;
using System.Transactions;

namespace baseprotect
{
    public enum State
    {
        NotNotified = 0,
        Notified,
        NotifiedAgain,
        Ignoring,
        Exported,
        
        PaidSigned,
        PaidSignedModified,
        PaidNotSigned,
        
        CreditSigned,
        CreditSignedModified,
        CreditNotSigned,

        NotPaid,
        Negotiation
    }

    public enum NotifyType
    {
        Notify = 0,
        Export
    };

    [Table(Name="Person")]
    public class Person
    {
        int id;

        string name;
        string sname;
        string email;
        string isp_name;
        string city;
        string postal;
        string details;
        string baseprotectID;

        EntityRef<PersonPenalty> penalty = new EntityRef<PersonPenalty>();
        EntitySet<PersonPayment> payments = new EntitySet<PersonPayment>();
        EntityRef<Info> info = new EntityRef<Info>();
        EntitySet<Note> notes = new EntitySet<Note>();
        EntitySet<Notify> notifies = new EntitySet<Notify>();
        EntitySet<PersonState> states = new EntitySet<PersonState>();
        EntitySet<PersonToEvent> events_relation = new EntitySet<PersonToEvent>();
        EntitySet<Reminder> reminders = new EntitySet<Reminder>();

        private PersonState cachedCurrentState;

        [Column(IsPrimaryKey = true, Storage = "id", Name="id", IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; } 
        }

        [Column(Storage = "name", Name="first_name")]
        public string FirstName
        {
            get {   return this.name; }
            set {   this.name = value; }
        }

        [Column(Storage="sname", Name="second_name")]
        public string SecondName
        {
            get {   return this.sname; }
            set {   this.sname = value; }
        }

        [Column(Storage="email", Name="email")]
        public string Email
        {
            get {   return this.email; }
            set {   this.email = value; }
        }

        [Column(Storage="isp_name", Name="isp_name")]
        public string ISPName
        {
            get {   return this.isp_name; }
            set {   this.isp_name = value; }
        }

        [Column(Storage = "city", Name="adress_city")]
        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        [Column(Storage = "postal", Name="adress_postal")]
        public string Postal
        {
            get { return postal.Trim().PadLeft(5, '0'); }
            set { postal = value; }
        }

        [Column(Storage = "details", Name="adress_details")]
        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        [Column(Storage = "baseprotectID", Name = "baseprotectid")]
        public string BaseprotectID
        {
            get { return baseprotectID; }
            set { baseprotectID = value; }
        }

        [Association(Name="PersonNotifies", Storage="notifies", OtherKey="PersonID")]
        public EntitySet<Notify> Notifies 
        {
            get { return notifies; }
            set { notifies.Assign(value); }
        }

        [Association(Name="PersonNotes", Storage="notes", OtherKey="PersonID" )]
        public EntitySet<Note> Notes
        {
            get { return notes; }
            set { notes.Assign(value); }
        }

        [Association(Name="PersonStates", Storage="states", OtherKey="OwnerID")]
        public EntitySet<PersonState> States
        {
            get { return states; }
            set {  states.Assign(value);  }
        }

        [Association(Name = "InfoPerson", Storage = "info", ThisKey = "BaseprotectID", OtherKey = "BennKenn", IsForeignKey = false)]
        public Info Info
        {
            get { return info.Entity; }
            set { info.Entity = value; }
        }

        public PersonState CurrentState
        {
            get 
            {
                if(cachedCurrentState == null)
                    cachedCurrentState = GetPersonCurrentState(this);
                return cachedCurrentState;
            }
            set 
            {
                cachedCurrentState = value;
                SetPersonCurrentState( this, value ); 
            }
        }

        public EnumerableWrapper<NetEvent> Events
        {
            get { return GetEvents(Config.ActiveProject, false); }
        }

        public EnumerableWrapper<NetEvent> GetEvents(Project project, bool refresh)
        {
            var events = CompiledQueries.eventsQuery(Config.DB, ID, project.ID);
            return new EnumerableWrapper<NetEvent>(events);
        }

        public String FilesNo
        {
            get { return string.Format("{0}-{1}", BaseprotectID, SchuldnerNo); }
        }
 
        [Association(Name = "PersonToEvent", Storage="events_relation", OtherKey="PersonID")]
        public EntitySet<PersonToEvent> EventsRelation
        {
            get{ return events_relation;}
            set{ events_relation.Assign(value);} 
        }

        public IQueryable<Project> Projects
        {
            get
            {
                return (from pip in Config.DB.PersonInProject
                       where pip.Person.ID == ID
                       select pip.Project).Distinct();
            }
        }

        public int ProjectsCount
        {
            get { return Projects.Count(); }
        }

        //To access in Pdf generator
        public Project ActiveProject
        {
            get { return Config.ActiveProject; }
        }

        public String PenaltyDate
        {
            get { return DateTime.Now.AddDays(ActiveProject.PaymentAfter).ToShortDateString(); }
        }

        public String LawyersNames
        {
            get 
            {
                return String.Join(",", GetLawyers().Select(x => x.Lawyer).Select(x => x.ToString()).ToArray());
            }
        }

        public PersonState ChangeState(State newState, String comment,
            String DocumentPath, Project Project)
        {
            Document document = new Document();
            PersonState state = new PersonState();

            state.Owner = this;
            state.State = newState;
            state.Comment = comment;
            state.Date = DateTime.Now;
            state.Project = Project;
            CurrentState = state;

            if (!String.IsNullOrEmpty(DocumentPath))
            {
                document = new Document(DocumentPath.Trim());
                state.Document = document;
            }

            if (state.State == State.PaidSigned)
            {
                PersonPayment p = new PersonPayment
                {
                    ID = new Random().Next(),
                    Date = DateTime.Now,
                    ProjectID = Config.ActiveProject.ID,
                    Type = PaymentType.Other,
                    PersonID = ID,
                    Comment = "Automatic payment",

                    Amount = PenaltyAmount()
                };

                Payments.Add(p);
            }

            States.Add(state);
            return state;
        }

        public static PersonState GetPersonCurrentState(Person person)
        {
            return person.GetCurrentState();
        }

        public static void SetPersonCurrentState(Person person, PersonState state)
        {
            person.SetCurrentState(state);
        }

        public PersonState GetCurrentState()
        {
            return States.OrderByDescending(s => s.Date).First();
        }

        public void SetCurrentState(PersonState state)
        {
            States.Add(state);
        }

        public int SchuldnerNo
        {
            get { return ActiveProject.Schuldner.Value + id; }
        }

        public int HAUPTF
        {
            get{ return 1; }
        }

        public string FullName
        {
            get { return String.Format("{0}, {1}", SecondName, FirstName);  }
        }

        #region Lawyers
        public void AddLawyer(Lawyer lawyer)
        {
            var rel = Config.DB.PersonToLawyer.FirstOrDefault(x => x.Lawyer == lawyer && x.Person == this);
            if (rel == null) 
                Config.DB.PersonToLawyer.InsertOnSubmit(new PersonToLawyer { Person = this, Lawyer = lawyer, Project = ActiveProject });
        }

        public void RemoveLawyer(Lawyer p)
        {
            var rel = Config.DB.PersonToLawyer.FirstOrDefault(x => x.LawyerID == p.ID && x.Person == this);
            if(rel != null)
                Config.DB.PersonToLawyer.DeleteOnSubmit(rel);
        }

        public IEnumerable<PersonToLawyer> GetLawyers()
        {
            return Config.DB.PersonToLawyer
                .Where(x => x.Person == this)
                .Where(p => p.Project == ActiveProject);
        }

        //#region RelationDeatils
        //private EntitySet<PersonToLawyer> _relation = new EntitySet<PersonToLawyer>();
        //[Association(Name = "PersonToLawyer", Storage = "_relation", OtherKey = "PersonID", ThisKey="ID")]
        //private EntitySet<PersonToLawyer> _LawyerRelation
        //{
        //    get { return _relation; }
        //    set { _relation.Assign(value); }
        //}

        //public IEnumerable<KeyValuePair<Project, Lawyer>> LawyerWithProject
        //{
        //    get { return _LawyerRelation.Select(x => new KeyValuePair<Project, Lawyer>(x.Project, x.Lawyer)); }
        //}

        //#endregion
        #endregion

        #region Payments
        [Association(Name = "PersonPenalty", Storage = "penalty", OtherKey = "PersonID")]
        public PersonPenalty Penalty
        {
            get { return penalty.Entity; }
            set { penalty.Entity = value; }
        }

        [Association(Name = "PersonPayments", Storage = "payments", OtherKey = "PersonID")]
        public EntitySet<PersonPayment> Payments
        {
            get { return payments; }
            set { payments.Assign(value); }
        }

        public IEnumerable<PersonPayment> ProjectPayments()
        {
            return Payments.Where(p => p.Project == ActiveProject);
        }

        public decimal PaymentsAmount()
        {
            var p = ProjectPayments();
            return p.Sum(x => x.Amount);
        }

        public decimal PenaltyAmount()
        {
            if (Penalty != null && Penalty.Project == ActiveProject)
                return Penalty.Penalty;
            return ActiveProject.Penalty;
        }

        public string PenaltyString
        {
            get { return String.Format("{0:N}", PenaltyAmount()); }
        }
        #endregion

        [Association(Name = "PersonReminders", Storage = "reminders", OtherKey = "PersonID", IsForeignKey = true)]
        public EntitySet<Reminder> Reminders
        {
            get { return reminders; }
            set { reminders.Assign(value); }
        }
    }

    [Table(Name = "PersonState")]
    public class PersonState
    {
        private int id;
        private int person_id;
        private int document_id;
        private string comment;
        private int project_id;
        private DateTime date;
        private State state;

        EntityRef<Person> owner = new EntityRef<Person>();
        EntityRef<Document> document = new EntityRef<Document>();
        EntityRef<Project> project = new EntityRef<Project>(); 

        [Column(Name="id", Storage="id", IsDbGenerated=true, IsPrimaryKey=true)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "date", Storage = "date")]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Column(Name = "type", Storage = "state")]
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        [Column(Name = "comment", Storage = "comment")]
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        [Column( Name = "person_id", Storage = "person_id" )]
        public int OwnerID
        {
            get { return person_id; }
            set { person_id = value; }
        }

        [Column(Name = "project_id", Storage = "project_id")]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Column(Name = "document_id", Storage = "document_id")]
        public int DocumentID
        {
            get { return document_id; }
            set { document_id = value; }
        }

        [Association( Name = "PersonStates", Storage = "owner", ThisKey = "OwnerID", IsForeignKey = true)]
        public Person Owner
        {
            get { return owner.Entity; }
            set { owner.Entity = value; }
        }

        [Association( Name="StateDocument", Storage="document", ThisKey="DocumentID", IsForeignKey=true)]
        public Document Document
        {
            get { return document.Entity; }
            set { document.Entity = value; }
        }

        [Association(Name = "Project", ThisKey = "ProjectID", Storage = "project", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }
    }

    [Table(Name="Event")]
    public class NetEvent
    {
        private int id;
        private int dbindex;
        
        private string ip;
        private string hash;
        private string guid;
        private string serwer;
        private string benn_kenn;
        private string publish;
        private string plugin;

        private DateTime time;
        private DateTime date;

        private int project_id;

        EntityRef<PersonToEvent> owner_relation = new EntityRef<PersonToEvent>();
        EntityRef<Project> project = new EntityRef<Project>();

        [Column(IsPrimaryKey = true, Storage = "id", Name="id", IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get {   return id; }
            set {   id = value; }
        }

        [Column(Storage="guid", Name="guid")]
        public string GUID
        {
            get 
            {
                if (guid.StartsWith("btc") || guid.StartsWith("ed2k") || guid.StartsWith("ftp"))
                    return guid.GetMd5Hash();
                return guid; 
            }
            set {   guid = value; }
        }

        [Column(Storage="hash", Name="hash")]
        public string Hash
        {
            get {   return hash; }
            set {   hash = value; }
        }

        [Column(Storage="time", Name="time")]
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        [Column(Storage="date", Name="date")]
        public DateTime Date
        {
            get {  return date; }
            set { date = value; }
        }

        [Column(Storage="serwer", Name="server")]
        public string Server
        {
            get {   return serwer; }
            set {   serwer = value; }
        }

        [Column(Storage="ip", Name="ip") ]
        public string IP
        {
            get {   return ip; }
            set {   ip = value; }
        }

        [Column(Storage="benn_kenn", Name="benn_kenn")]
        public string BennKenn
        {
            get {   return benn_kenn; }
            set {   benn_kenn = value; }
        }

        [Column(Storage="dbindex", Name="dbindex")]
        public int DBIndex
        {
            get{ return dbindex; }
            set{ dbindex = value;}
        }

        [Column(Storage = "plugin", Name = "plugin")]
        public string Plugin
        {
            get { return plugin; }
            set { plugin = value; }
        }

        [Column(Storage = "publish", Name = "publish")]
        public string Publish
        {
            get { return publish; }
            set { publish = value; }
        }

        [Column(Storage = "project_id", Name = "project_id")]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        public string Title
        {
            get { return serwer; }
        }

        [Association(Name = "EventToPerson", Storage = "owner_relation", OtherKey="EventID")]
        public PersonToEvent OwnerRelation
        {
            get{ return owner_relation.Entity;}
            set{ owner_relation.Entity = value;}
        }

        [Association(Name = "EventInProject", Storage = "project", ThisKey = "ProjectID")]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }

        public DateTime FullDate
        {
            get { return Utils.CombineDateAndTime(Date, Time.TimeOfDay); }
        }
    }

    [Table(Name="PersonToEvent")]
    public class PersonToEvent
    {
        private int id;
        private int person_id;
        private int ev_id;

        EntityRef<Person> owner = new EntityRef<Person>();
        EntityRef<NetEvent> ev = new EntityRef<NetEvent>(); 

        [Column( Name = "id", Storage = "id", CanBeNull = false, IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID
        {
            get{ return id; }
            set { id = value; }
        }

        [Column(Storage="ev_id", Name="event_id", CanBeNull=false)]
        public int EventID
        {
            get {   return ev_id; }
            set {   ev_id = value; }
        }

        [Column(Storage = "person_id", Name = "person_id", CanBeNull=false)]
        public int PersonID
        {
            get {   return person_id; }
            set {   person_id = value; }
        }

        [Association(Name = "PersonToEvent", Storage = "owner", IsForeignKey = true, ThisKey = "PersonID")]
        public Person Owner
        {
            get { return owner.Entity; }
            set { owner.Entity = value; }
        }

        [Association(Name = "EventToPerson", Storage = "ev", IsForeignKey = true, ThisKey = "EventID")]
        public NetEvent Event
        {
            get { return ev.Entity; }
            set { ev.Entity = value; }
        }
    }

    [Table(Name = "Notify")]
    public class Notify
    {
        private int id;
        private DateTime date;

        private int person_id;
        private int document_id;
        private int state_id;
        private int project_id;

        private NotifyType type;

        private EntityRef<PersonState> state = new EntityRef<PersonState>();
        private EntityRef<Document> document = new EntityRef<Document>();
        private EntityRef<Person> person = new EntityRef<Person>();
        private EntityRef<Project> project = new EntityRef<Project>();

        [Column(Storage = "id", Name = "id", IsDbGenerated = true, IsPrimaryKey=true)]
        public int ID
        {
            get { return id; }
            set { id = value; }    
        }

        [Column(Storage = "date", Name = "date")]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Column( Storage = "document_id", Name = "document_id", CanBeNull = true )]
        public int DocumentID
        {
            get { return document_id; }
            set { document_id = value; }
        }

        [Column( Storage = "person_id", Name = "person_id" )]
        public int PersonID
        {
            get { return person_id; }
            set { person_id = value; }
        }

        [Column(Storage = "state_id", Name = "state_id")]
        public int StateID
        {
            get{ return state_id;}
            set{ state_id = value;}
        }

        [Column(Storage = "project_id", Name = "project_id")]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Column(Storage = "type", Name = "type")]
        public NotifyType Type
        {
            get { return type; }
            set { type = value; }
        }

        [Association(Name="NotifyState", ThisKey="StateID", Storage="state", IsForeignKey=true)]
        public PersonState State
        {
            get{ return state.Entity;}
            set{ state.Entity = value;}
        }

        [Association(Name="PersonNotifies", ThisKey="PersonID", Storage="person", IsForeignKey = true)]
        public Person Notified
        {
            get { return person.Entity; }
            set { person.Entity = value; }
        }

        [Association( Name = "NotifyDocument", ThisKey = "DocumentID", Storage = "document")]
        public Document Document
        {
            get { return document.Entity; }
            set { document.Entity = value; }
        }

        [Association(Name = "Project", ThisKey = "ProjectID", Storage = "project", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }
    }

    [Table(Name = "Document")]
    public class Document
    {
        private int id;
        private int order;
        private String type;
        private Binary raw_document;

        EntityRef<Notify> notify = new EntityRef<Notify>();
        EntityRef<PersonState> state = new EntityRef<PersonState>();

        public Document(){}

        public Document(String path)
        {
            if (String.IsNullOrEmpty(path))
                return;

            /*using( FileStream stream = new FileStream(path, FileMode.Open))
            {
                byte[] DocumentData = Utils.ReadFully(stream);
                //RawDocument = new Binary(DocumentData);
                Type = Path.GetExtension(path);
            }
            */

            Type = Path.GetExtension(path);
        }

        [Column(Name="id", Storage="id", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public int ID 
        { 
            get{ return id;}
            set { id = value; }
        }

        [Column(Name="order_", Storage="order")]
        public int Order
        { 
            get{return order;}
            set{order = value;} 
        }

        [Column(Name = "raw_document", Storage = "raw_document", DbType = "Image(max)")]
        public Binary RawDocument
        {
            get { return raw_document; }    
            set{ raw_document = value;}
        }

        [Column(Name = "type", Storage = "type")]
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        [Association( Name="StateDocument", Storage="state", OtherKey="DocumentID", IsForeignKey=true)]
        public PersonState State
        { 
            get{return state.Entity;}
            set{state.Entity = value;} 
        }

        [Association( Name = "NotifyDocument", Storage = "notify", OtherKey = "DocumentID", IsForeignKey = true )]
        public Notify Notify
        {
            get { return notify.Entity; }
            set { notify.Entity = value; }
        }
    }

    [Table(Name = "Template")]
    public class Template
    {
        private int id;
        private int order;
        private int project_id;
        private Binary raw_template;

        EntityRef<Project> project = new EntityRef<Project>();

        [Column(Name="id", Storage="id", IsPrimaryKey=true, IsDbGenerated=true)]
        public int ID 
        { 
            get { return id;    }
            set { id = value;   }  
        }

        [Column(Name="order_", Storage="order")]
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        [Column(Name="raw_template", Storage="raw_template", CanBeNull=true, DbType="Image(max) NULL", UpdateCheck = UpdateCheck.Never)]
        public Binary RawTemplate
        {
            get{ return raw_template;}
            set{ raw_template = value;}
        }

        [Column(Name = "project_id", Storage = "project_id")]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Association(Name = "TemplateProject", ThisKey = "ProjectID", Storage = "project", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }
    }

    [Table(Name="Note")]
    public class Note
    {
        enum NoteType : int
        {
            info = 0,
            warning = 1
        }

        private int id;
        private int person_id;

        private string author;
        private string text;
        private DateTime date;

        private EntityRef<Person> owner = new EntityRef<Person>();

        [Column(Name="id", Storage="id", IsDbGenerated=true, IsPrimaryKey=true, CanBeNull=false)]
        public int ID
        { 
            get{ return id; } 
            set{ id=value;  } 
        }

        [Column(Name="text", Storage="text")]
        public String Text
        {
            get { return text; }
            set { text = value; }
        }

        [Column(Name="date", Storage="date")]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Column(Name="person_id", Storage="person_id")]
        public int PersonID 
        {
            get { return person_id; }
            set{ person_id = value;}
        }

        [Column( Name = "author", Storage = "author" )]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        [Association(Name="PersonNotes", Storage="owner", ThisKey = "PersonID")]
        public Person Owner 
        {
            get { return owner.Entity; }
            set { owner.Entity = value; }
        }
    }

    [Table(Name = "Info")]
    public class Info
    {
        private int id;

        private String mandatNr;
        private String projectPrefix;
        private String category;
        private String productName;
        private DateTime? productReleaseDate;
        private DateTime? warrantDate;
        private decimal penalty;
        private String bennKenn;

        private EntitySet<Person> persons = new EntitySet<Person>();

        [Column(Name="id", Storage="id", IsDbGenerated=true, IsPrimaryKey=true, CanBeNull = false)]
        public int ID
        {
            get{ return id;}
            set{ id = value;}
        }

        [Column(Name="mandat_nr", Storage="mandatNr")]
        public string MandatNr
        {
            get{ return mandatNr;}
            set{ mandatNr = value;}
        }

        [Column(Name = "category", Storage = "category")]
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        [Column(Name = "project_prefix", Storage = "projectPrefix")]
        public string ProjectPrefix
        {
            get { return projectPrefix; }
            set { projectPrefix = value; }
        }

        [Column(Name = "product_name", Storage = "productName")]
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        [Column(Name = "product_release_date", Storage = "productReleaseDate")]
        public DateTime? ProductReleaseDate
        {
            get { return productReleaseDate; }
            set { productReleaseDate = value; }
        }

        [Column(Name = "warrant_date", Storage = "warrantDate")]
        public DateTime? WarrantDate
        {
            get { return warrantDate; }
            set { warrantDate = value; }
        }

        [Column(Name = "penalty", Storage = "penalty")]
        public decimal Penalty
        { 
            get { return penalty; }
            set { penalty = value; }
        }

        public String PenaltyString
        {
            get { return penalty.ToString("C"); }
        }

        [Column(Name = "benn_kenn", Storage = "bennKenn", CanBeNull = false)]
        public string BennKenn
        {
            get { return bennKenn; }
            set { bennKenn = value; }
        }

        [Association(Name = "InfoPerson", Storage = "persons", ThisKey = "BennKenn", OtherKey = "BaseprotectID", IsForeignKey = false)]
        public EntitySet<Person> Persons
        {
            get { return persons; }
            set { persons.Assign(value);}
        }
    }

    [Table(Name = "JoinProcess")]
    public class JoinProcess
    {
        private int id;

        private DateTime date;
        
        private String bp_file;
        private String isp_file;

        private int isp_count;
        private int bp_count;
        private int duplicated_count;

        //private EntitySet<Person> persons = new EntitySet<Person>();
        //private EntitySet<NetEvent> events = new EntitySet<NetEvent>();

        [Column(Name = "id", Storage = "id", IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "date", Storage = "date", CanBeNull = false)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /*
        [Column(Name = "baseprotect_file", CanBeNull = false)]
        public String BPFilename
        {
            get { return bp_file; }
            set { bp_file = value; }
        }

        [Column(Name = "provider_file", CanBeNull = false)]
        String ISPFilename
        {
            get { return isp_file; }
            set { isp_file = value; }
        }
        */

        [Column(Name = "provider_count", CanBeNull = false)]
        public int ISPCount
        {
            get { return isp_count; }
            set { isp_count = value; }
        }

        [Column(Name = "baseprotect_count", CanBeNull = false)]
        public int BPCount
        {
            get { return bp_count; }
            set { bp_count = value; }
        }

        [Column(Name = "duplicated_count", CanBeNull = false)]
        public int DuplicatedCount
        {
            get { return duplicated_count; }
            set { duplicated_count = value; }
        }

        public void SetProcessData(int writtenCount, Table ispTable, Table bpTable)
        {
            date = DateTime.Now;

            bp_count = bpTable.Count;
            isp_count = bpTable.Count;

            duplicated_count = isp_count - writtenCount;
        }
    }

    [Table(Name = "ExportProcess")]
    public class ExportProcess
    {
        private int id;
        private DateTime date;
        private int count;

        public ExportProcess(int c)
        {
            count = c;
            date = DateTime.Now;
        }

        [Column(Name = "id", Storage = "id", IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "date", CanBeNull = false)]
        public DateTime Date
        {
            get { return date; }
            set { date= value; }
        }

        [Column(Name = "count", CanBeNull = false)]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }

    [Table(Name = "Project")]
    public class Project
    {
        const int DEFAULT_SCHULDNER = 100000;

        private int id;
        private string name;
        private int deadline;
        private int? schuldner;
        private decimal penalty;
        private int ignore_after;
        private DateTime creation_date;

        EntitySet<Template> templates = new EntitySet<Template>();
        EntitySet<Person> persons = new EntitySet<Person>();
        EntitySet<PersonPayment> payments = new EntitySet<PersonPayment>();
        EntitySet<Reminder> reminders = new EntitySet<Reminder>();

        [Column(Name = "id", Storage = "id", IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "name", CanBeNull = false)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Column(Name = "penalty", CanBeNull = false)]
        public decimal Penalty
        {
            get { return penalty; }
            set { penalty = value; }
        }

        [Column(Name = "payment_after", CanBeNull = false)]
        public int PaymentAfter
        {
            get { return deadline; }
            set { deadline = value; }
        }

        [Column(Name = "ignore_after", CanBeNull = false)]
        public int IgnoreAfter
        {
            get { return ignore_after; }
            set { ignore_after = value; }
        }

        [Column(Name = "creation_date", CanBeNull = false)]
        public DateTime CreationDate
        {
            get { return creation_date; }
            set { creation_date = value; }
        }

        [Column(Name = "schuldner", Storage = "schuldner", CanBeNull = true)]
        public int? Schuldner
        {
            get{
                if (schuldner == null)
                    return DEFAULT_SCHULDNER;
                return schuldner; 
            }
            
            set { schuldner = value; }
        }

        [Association(Name = "ProjectTemplates", Storage = "templates", OtherKey = "ProjectID")]
        public EntitySet<Template> Templates
        {
            get { return templates; }
            set { templates.Assign(value); }
        }

        private EnumerableWrapper<Person> GetPersons()
        {
            var persons = CompiledQueries.projectPersonQuery(Config.DB, Config.ActiveProject.ID);
            return new EnumerableWrapper<Person>(persons);
        }

        public EnumerableWrapper<Person> Persons
        {
            get { return GetPersons(); }
        }

        private EnumerableWrapper<NetEvent> GetEvents(int ProjectID)
        {
            var events = CompiledQueries.projectEventsQuery(Config.DB, ProjectID);
            return new EnumerableWrapper<NetEvent>(events);
        }

        public EnumerableWrapper<NetEvent> Events
        {
            get { return GetEvents(Config.ActiveProject.ID); }
        }

        public void AddPersonToProject(Person person)
        {
            PersonInProject pip = new PersonInProject();
            pip.Person = person;
            pip.Project = this;

            if (person.ID != 0)
            {
                var q = from p in Config.DB.PersonInProject
                        where p.Project == this && p.Person == person
                        select p;

                if (q.FirstOrDefault() != null)
                    return;
            }

            Config.DB.PersonInProject.InsertOnSubmit(pip);
        }

        public void Detach()
        {
            Templates = default(EntitySet<Template>);
            persons = default(EntitySet<Person>);            
        }

        [Association(Name = "ProjectPayments", Storage = "payments", OtherKey = "ProjectID")]
        public EntitySet<PersonPayment> Payments
        {
            get { return payments; }
            set { payments.Assign(value); }
        }

        [Association(Name = "ProjectReminders", Storage = "reminders", OtherKey = "ProjectID")]
        public EntitySet<Reminder> Reminders
        {
            get { return reminders; }
            set { reminders.Assign(value); }
        }
    }

    [Table(Name = "PersonInProject")]
    public class PersonInProject
    {
        private int id;
        private int project_id;
        private int person_id;
        private int schuldner;

        EntityRef<Project> project = new EntityRef<Project>();
        EntityRef<Person> person = new EntityRef<Person>();

        [Column(Name = "project_id", Storage = "project_id", CanBeNull = false, IsPrimaryKey = true)]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Column(Name = "person_id", Storage = "person_id", CanBeNull = false, IsPrimaryKey = true)]
        public int PersonID
        {
            get { return person_id; }
            set { person_id = value; }
        }

        [Association(Name = "ProjectPerson", Storage = "project", ThisKey = "ProjectID", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }
        [Association(Name = "PersonProject", Storage = "person", ThisKey = "PersonID", IsForeignKey = true)]
        public Person Person
        {
            get { return person.Entity; }
            set { person.Entity = value; }
        }
    }

    [Table(Name="Lawyer")]
    public class Lawyer
    {
        int id;
        string name;
        string sname;
        string adress;
        string email;

        [Column(Name = "id", Storage = "id", IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "name", CanBeNull = false)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Column(Name = "sname", CanBeNull = false)]
        public string SName
        {
            get { return sname; }
            set { sname = value; }
        }

        [Column(Name = "adress", CanBeNull = false)]
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        [Column(Name = "email", CanBeNull = false)]
        public string EMail
        {
            get { return email; }
            set { email = value; }
        }

        public String EMailLink
        {
            get { return String.Format("mailto:{0}", EMail); } 
        }

        public IEnumerable<Project> Projects
        {
            get { return _PersonRelation.Select(x => x.Project); }
        }

        public String ProjectsList
        {
            get { return String.Join(",", Projects.Select(p => p.Name).ToArray()); }
        }

        #region Persons
        private EntitySet<Person> _persons;
        public EntitySet<Person> Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = new System.Data.Linq.EntitySet<Person>(OnPersonAdd, OnPersonRemove);
                    _persons.SetSource(_PersonRelation.Select(x => x.Person));
                }
                return _persons;
            }
            set
            {
                _persons.Assign(value);
            }
        }

        private void OnPersonAdd(Person person)
        {
            var rel = _PersonRelation.FirstOrDefault(x => x.PersonID == person.ID);
            if (rel == null) 
                _PersonRelation.Add(new PersonToLawyer { 
                    Person = person, 
                    Lawyer = this, 
                    Project = person.ActiveProject 
                });
        }

        private void OnPersonRemove(Person p)
        {
            var rel = _PersonRelation.FirstOrDefault(x => x.PersonID == p.ID);
            _PersonRelation.Remove(rel);
            rel.Remove();
        }

        #region RelationDeatils
        private EntitySet<PersonToLawyer> _relation = new EntitySet<PersonToLawyer>();
        [Association(Name = "LawyerToPerson", Storage = "_relation", OtherKey = "LawyerID")]
        private EntitySet<PersonToLawyer> _PersonRelation
        {
            get { return _relation; }
            set { _relation.Assign(value); } 
        }
        #endregion

        #endregion

        public override string ToString()
        {
            return String.Format("{0} {1}", Name, SName);
        }
    }

    [Table(Name="PersonToLawyer")]
    public class PersonToLawyer
    {
        private int project_id;
        private int person_id;
        private int lawyer_id;

        EntityRef<Person> person = new EntityRef<Person>();
        EntityRef<Lawyer> lawyer = new EntityRef<Lawyer>();
        EntityRef<Project> project = new EntityRef<Project>();

        [Column(Name = "person_id", Storage = "person_id", CanBeNull = false, IsPrimaryKey = true)]
        public int PersonID
        {
            get { return person_id; }
            set { person_id = value; }
        }

        [Column(Name = "lawyer_id", Storage = "lawyer_id", CanBeNull = false, IsPrimaryKey = true)]
        public int LawyerID
        {
            get { return lawyer_id; }
            set { lawyer_id = value; }
        }

        [Column(Name = "project_id", Storage = "project_id", CanBeNull = false, IsPrimaryKey = true)]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Association(Name = "LawyerToPersonInProject", Storage = "project", ThisKey = "ProjectID", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }

        [Association(Name = "LawyerToPerson", Storage="lawyer", ThisKey = "LawyerID", 
            IsForeignKey = true, DeleteOnNull = true)]
        public Lawyer Lawyer
        {
            get { return lawyer.Entity; }
            set { lawyer.Entity = value; }
        }

         [Association(Name = "PersonToLawyer", Storage="person", ThisKey = "PersonID",
             IsForeignKey = true, DeleteOnNull = true)]
         public Person Person
         {
             get { return person.Entity; }
             set { person.Entity = value; }
         }

         public void Remove()
         {
             Person = null;
             Lawyer = null;
         }
    }

    public enum PaymentType
    {
        Cash = 1,
        Transfer = 2,
        Postal = 3,
        Other = 4
    };

    [Table(Name = "PersonPayment")]
    public class PersonPayment
    {
        private int id;
        private int project_id;
        private int person_id;
        private decimal amount;
        private DateTime date;
        private string comment;
        private PaymentType type;

        EntityRef<Person> person = new EntityRef<Person>();
        EntityRef<Project> project = new EntityRef<Project>();

        [Column(IsPrimaryKey = true, Storage = "id", Name = "id", CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "person_id", Storage = "person_id", IsPrimaryKey = true)]
        public int PersonID
        {
            get { return person_id; }
            set { person_id = value; }
        }

        [Column(Name = "project_id", Storage = "project_id", IsPrimaryKey = true)]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Column(Name = "date", Storage = "date", CanBeNull = false)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Column(Name = "amount", Storage = "amount", CanBeNull = false)]
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        [Column(Name = "comment", Storage = "comment")]
        public String Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        [Column(Name = "type", Storage = "type", CanBeNull = false)]
        public PaymentType Type
        {
            get { return type; }
            set { type = value; }
        }

        [Association(Name = "ProjectPayments", Storage = "project", ThisKey = "ProjectID", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }

        [Association(Name = "PersonPayment", Storage = "person", ThisKey = "PersonID",
            IsForeignKey = true, DeleteOnNull = true)]
        public Person Person
        {
            get { return person.Entity; }
            set { person.Entity = value; }
        }
    }

    [Table(Name = "PersonPenalty")]
    public class PersonPenalty
    {
        private int id;
        private int project_id;
        private int person_id;
        private decimal penalty;
        private DateTime date;
        private string comment;

        EntityRef<Person> person = new EntityRef<Person>();
        EntityRef<Project> project = new EntityRef<Project>();

        [Column(IsPrimaryKey = true, Storage = "id", Name = "id", CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "person_id", Storage = "person_id", CanBeNull = false, IsPrimaryKey = true)]
        public int PersonID
        {
            get { return person_id; }
            set { person_id = value; }
        }

        [Column(Name = "project_id", Storage = "project_id", CanBeNull = false, IsPrimaryKey = true)]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Column(Name = "date", Storage = "date", CanBeNull = false)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Column(Name = "amount", Storage = "penalty", CanBeNull = false)]
        public decimal Penalty
        {
            get { return penalty;  }
            set { penalty = value; }
        }

        [Column(Name = "comment", Storage = "comment")]
        public String Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        [Association(Name = "PaymentInProject", Storage = "project", ThisKey = "ProjectID", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }

        [Association(Name = "PersonPenalty", Storage = "person", ThisKey = "PersonID",
            IsForeignKey = true, DeleteOnNull = true)]
        public Person Person
        {
            get { return person.Entity; }
            set { person.Entity = value; }
        }
    }

    [Table(Name = "Reminder")]
    public class Reminder
    {
        private int id;
        private int person_id;
        private int note_id;
        private int project_id;

        private DateTime creation_date;
        private DateTime last_post;

        private int peroid;
        private int cyclic;

        EntityRef<Person> person = new EntityRef<Person>();
        EntityRef<Project> project = new EntityRef<Project>();
        EntityRef<Note> note = new EntityRef<Note>();

        [Column(IsPrimaryKey = true, Storage = "id", Name = "id", IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Name = "person_id", Storage = "person_id", CanBeNull = false, IsPrimaryKey = true)]
        public int PersonID
        {
            get { return person_id; }
            set { person_id = value; }
        }

        [Column(Name = "project_id", Storage = "project_id", CanBeNull = false, IsPrimaryKey = true)]
        public int ProjectID
        {
            get { return project_id; }
            set { project_id = value; }
        }

        [Column(Name = "note_id", Storage = "note_id", CanBeNull = false, IsPrimaryKey = true)]
        public int NoteID
        {
            get { return note_id; }
            set { note_id = value; }
        }

        [Column(Name = "creation_date", Storage = "creation_date", CanBeNull = false)]
        public DateTime CreationDate
        {
            get { return creation_date; }
            set { creation_date = value; }
        }

        [Column(Name = "peroid", Storage = "peroid", CanBeNull = false)]
        public int Peroid
        {
            get { return peroid; }
            set { peroid = value; }
        }

        [Column(Name = "cyclic", Storage = "cyclic", CanBeNull = false)]
        public int Cyclic
        {
            get { return cyclic; }
            set { cyclic = value; }
        }

        [Column(Name = "last_post", Storage = "last_post")]
        public DateTime LastPost
        {
            get { return last_post; }
            set { last_post = value; }
        }

        [Association(Name = "ProjectReminders", Storage = "project", ThisKey = "ProjectID", IsForeignKey = true)]
        public Project Project
        {
            get { return project.Entity; }
            set { project.Entity = value; }
        }

        [Association(Name = "PersonReminders", Storage = "person", ThisKey = "PersonID", IsForeignKey = true, DeleteOnNull = true)]
        public Person Person
        {
            get { return person.Entity; }
            set { person.Entity = value; }
        }

        [Association(Name = "ReminderNote", Storage = "note", ThisKey = "NoteID", IsForeignKey = true)]
        public Note Note
        {
            get { return note.Entity; }
            set { note.Entity = value; }
        }

        public DateTime PostDate
        {
            get { return creation_date.AddDays(Peroid); }
        }

        public void Post()
        {
            last_post = DateTime.Now;
            if (cyclic == 0)
                Config.DB.Reminders.DeleteOnSubmit(this);
        }

    }

    public class BaseprotectDB : DataContext
    {
        public Table<PersonToEvent> PersonsToEvents;
        public Table<Notify> Notifies;
        public Table<Note> Notes;
        public Table<Document> Documents;
        public Table<Template> Templates;
        public Table<PersonState> States;
        public Table<Info> Info;
        public Table<JoinProcess> JoinProcess;
        public Table<ExportProcess> Exports;
        public Table<Project> Projects;
        public Table<PersonInProject> PersonInProject;
        public Table<Lawyer> Lawyers;
        public Table<Person> Persons;
        public Table<NetEvent> Events;
        public Table<PersonPayment> Payments;
        public Table<PersonPenalty> Penalties;
        public Table<PersonToLawyer> PersonToLawyer;
        public Table<Reminder> Reminders;

        public BaseprotectDB(System.Data.IDbConnection connection)
            : base(connection)
		{
            PersonsToEvents = GetTable<PersonToEvent>();
            Notifies = GetTable<Notify>();
            Notes = GetTable<Note>();
            Documents = GetTable<Document>();
            Templates = GetTable<Template>();
            States = GetTable<PersonState>();
            Info = GetTable<Info>();
            JoinProcess = GetTable<JoinProcess>();
            Exports = GetTable<ExportProcess>();
            Projects = GetTable<Project>();
            PersonInProject = GetTable<PersonInProject>();
            Lawyers = GetTable<Lawyer>();
            Persons = GetTable<Person>();
            Events = GetTable<NetEvent>();
            Payments = GetTable<PersonPayment>();
            Penalties = GetTable<PersonPenalty>();
            PersonToLawyer = GetTable<PersonToLawyer>();
            Reminders = GetTable<Reminder>();
        }
    }
}

