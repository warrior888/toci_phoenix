using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.Interfaces;
using _3mb.Bll.Essential;
using _3mb.Bll.Interfaces.Localization;

namespace _3mb.Bll.Localization
{
    public class LocalizationLogic : BllDbLogic, ILocalizationLogic
    {
        private ISelect _select;
        private IInsert _insert;
        private IUpdate _update;
        private IDelete _delete;

        public LocalizationLogic(ISelect select, IInsert insert, IUpdate update, IDelete delete)
        {
            _select = select;
            _insert = insert;
            _update = update;
            _delete = delete;
        }
    }
}
