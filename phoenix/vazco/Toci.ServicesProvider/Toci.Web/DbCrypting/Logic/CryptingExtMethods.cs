using System;
using System.Collections.Generic;
using System.Diagnostics;
using EncodingLib;
using Toci.Db.DbVirtualization;

namespace DbCrypting.Logic
{
    public static class CryptingExtMethods
    {
        private const string InvalidPassword = "Invalid password!";


        public static void EncryptModel(this VazcoTable model, string secret)
        {

            var GenerateSecret = new GenerateSecret(secret);
            var hash = GenerateSecret.GetSecret();
            model.data = new TociCrypting().EncryptStringAes(model.data, secret, hash);
            model.hash = hash;

        }
        public static void DecryptDbModels(this List<VazcoTable> list, string secret)
        {

            foreach (var item in list)
            {
                var validatePassword = new VerifySecret(item.hash,secret);
                item.data = validatePassword.Verification() ? new TociCrypting().DecryptStringAes(item.data, secret, item.hash) : InvalidPassword;
            }
        }
        public static void FillAddInModel(this VazcoTable itemModel)
        {
            itemModel.name = DbUtils.GetUserNick();
            itemModel.addingTime = DateTime.Now;
        }
       
       
    }
}