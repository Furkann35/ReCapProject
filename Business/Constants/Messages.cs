using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda";

        public static string CarAdded = "Araba eklendi" ;
        public static string CarNameMinTwoCharacters = "Araba ismi minimüm 2 karakter olmalıdır." ;
        public static string CarDeleted = "Araç silindi" ;
        public static string CarListed = "Araç listelendi" ;

        public static string BrandListed = "Marka Listelendi" ;
        public static string BrandAdded = "Marka eklendi" ;

        public static string ColorAdded = "Renk eklendi" ;
        public static string ColorDeleted = "Renk silindi" ;

        public static string CustomerAdded = "Müşteri eklendi" ;
        public static string CustomerDeleted = "Müşteri silindi" ;

        public static string RentalAdded= "Araba kiralandı" ;
        public static string RentalDeleted= "Araba silindi" ;
        public static string RentalNotAdded = "Araba kiralanamadı" ;
        public static string RentalReturned = "Araba teslim alındı" ;

        public static string UserAdded = "Kullanıcı eklendi" ;
        public static string UserDeleted = "Kullanıcı silindi" ;

        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageLimit = "Araç resmi en fazla 5 tane olabilir";
        public static string CarImageNotFound = "Böyle bir resim bulunamıyor";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageUpdated = "Araç resmi güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
