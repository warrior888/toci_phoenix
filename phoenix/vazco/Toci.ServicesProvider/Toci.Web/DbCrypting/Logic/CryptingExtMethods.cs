using System;
using System.Collections.Generic;
using EncodingLib;

namespace DbCrypting.Logic
{
    public static class CryptingExtMethods
    {
        

        public static void EncryptModel(this DbModel model, string secret)
        {
            var GenerateSecret = new GenerateSecret(secret);
            var hash = GenerateSecret.GetSecret();
            model.data = new TociCrypting().EncryptStringAes(model.data, secret, hash);
            model.hash = hash;

        }
        public static void DecryptDbModels(this List<DbModel> list,string secret)
        {

            foreach (var item in list)
            {
                item.data = new TociCrypting().DecryptStringAes(item.data, secret, item.hash);
            }

        }
        public static void FillAddInModel(this QueryModel itemModel, DbModel model)
        {
            itemModel.SetNick(DbUtils.GetUserNick());
            itemModel.SetData(model.data);
            itemModel.SetTime(DateTime.Now);
            itemModel.SetHash(model.hash);
        }
    }
}