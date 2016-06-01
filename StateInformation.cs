using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace baseprotect
{
    class StateInfo
    {
        static Image NotifiedIcon =         Image.FromFile(@".\gfx\notified.ico");
        static Image NotNotifiedIcon =       Image.FromFile(@".\gfx\not_notified.png");
        static Image IgnoringIcon =         Image.FromFile(@".\gfx\ignoring.png");

        static Image PaidSigned =           Image.FromFile(@".\gfx\paid_signed.png");
        static Image PaidSignedModified =   Image.FromFile(@".\gfx\paid_signed_modified.png");
        static Image PaidNotSigned =        Image.FromFile(@".\gfx\paid_not_signed.png");

        static Image CreditSigned =         Image.FromFile(@".\gfx\credit_signed.png");
        static Image CreditSignedModified = Image.FromFile(@".\gfx\credit_signed_modified.png");
        static Image CreditNotSigned =      Image.FromFile(@".\gfx\credit_not_signed.png");

        static Image NotPaidIcon =          Image.FromFile(@".\gfx\not_paid.png");
        static Image NotifiedAgainIcon =    Image.FromFile(@".\gfx\notified_again.png" );

        static Image ExportedIcon = Image.FromFile(@".\gfx\exported.png");
        static Image NegotiationIcon = Image.FromFile(@".\gfx\negotiation.png");

        static Dictionary<State, SingleStateInfo> infos = new Dictionary<State, SingleStateInfo>()
            {
                {State.NotNotified, new SingleStateInfo("Persons not notified yet", NotNotifiedIcon)},
                {State.Notified,    new SingleStateInfo("Persons already notified", NotifiedIcon)},
                {State.NotifiedAgain, new SingleStateInfo("Persons notified more than once.", NotifiedAgainIcon)},
                {State.Ignoring,    new SingleStateInfo("Persons notified, but no response.", IgnoringIcon)},
                
                {State.PaidSigned,          new SingleStateInfo("Persons paying the penalty and signed original document", PaidSigned)},
                {State.PaidSignedModified,  new SingleStateInfo("Persons paying the penalty and signed modified document", PaidNotSigned)},
                {State.PaidNotSigned,       new SingleStateInfo("Persons paying the penalty but not signed any document",  PaidSignedModified)},
                
                {State.CreditSigned,         new SingleStateInfo("Persons paying on credit and signed original document", CreditSigned)},
                {State.CreditSignedModified, new SingleStateInfo("Persons paying on credit and signed modified document", CreditSignedModified)},
                {State.CreditNotSigned,      new SingleStateInfo("Persons paying on credit but not signed any document", CreditNotSigned)},

                {State.NotPaid, new SingleStateInfo("Person didn't paind any penalty.", NotPaidIcon)},
                {State.Negotiation, new SingleStateInfo("Negotiation.", NegotiationIcon)},

                {State.Exported, new SingleStateInfo("Exported.", ExportedIcon)},
            };

        public static SingleStateInfo GetInfo( State state )
        {
            return infos[state];
        }
    }

    class SingleStateInfo
    {
        public SingleStateInfo( string Description, Image Image )
        {
            description = Description;
            image = Image;
        }


        private string description;
        public string Description
        {
            get { return description; }
        }

        private Image image;
        public Image Image
        {
            get { return image; }
        }
    }
}