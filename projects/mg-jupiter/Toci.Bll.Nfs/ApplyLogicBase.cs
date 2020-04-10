using Toci.Bll.Nfs.Interfaces;
using Toci.Dal.Aoe.Interfaces;

namespace Toci.Bll.Nfs
{
    public class ApplyLogicBase : LogicBase<ApplyForm>, IApplyLogic
    {
        public ApplyLogicBase() : base(new Dal<ApplyForm>(new tociEntities()))
        {
        }

        public virtual ApplyForm SaveApply(ApplyForm form)
        {
            return Database.Insert(form);
        }
    }
}