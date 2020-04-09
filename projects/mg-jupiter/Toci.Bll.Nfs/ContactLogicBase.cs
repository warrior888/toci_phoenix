using Toci.Bll.Nfs.Interfaces;
using Toci.Dal.Aoe.Interfaces;

namespace Toci.Bll.Nfs
{
    public class ContactLogicBase : LogicBase<ContactForm>, IContactLogic
    {
        public ContactLogicBase() : base(new Dal<ContactForm>(new tociEntities()))
        {
        }

        public virtual ContactForm SaveContact(ContactForm form)
        {
            return Database.Insert(form);
        }
    }
}