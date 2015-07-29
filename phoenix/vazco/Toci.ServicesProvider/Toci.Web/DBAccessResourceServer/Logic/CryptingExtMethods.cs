using System;
using System.Collections.Generic;
using DBAccessResourceServer.Models;
using EncodingLib;

namespace DBAccessResourceServer.Logic
{
    public static class CryptingExtMethods
    {
        static readonly GenerateSecred GenerateSecret = new GenerateSecred(TemporarySecret);
        private const string TemporarySecret = "8a32d4v723s";

        public static void EncryptModel(this DbModel model)
        {

            var hash = GenerateSecret.GetSecret();
            model.data = new TociCrypting().EncryptStringAES(model.data, TemporarySecret, hash);
            model.hash = hash;

        }
        public static void DDecryptDbModels(this List<DbModel> list)
        {

            foreach (var item in list)
            {
                item.data = new TociCrypting().DecryptStringAES(item.data, TemporarySecret, item.hash);
            }

        }
        public static void FillAddInModel(this AddInModel itemModel, DbModel model)
        {
            itemModel.SetNick(DbUtils.GetUserNick());
            itemModel.SetData(model.data);
            itemModel.SetTime(DateTime.Now);
            itemModel.SetHash(model.hash);
        }
    }
}