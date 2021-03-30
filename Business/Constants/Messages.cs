using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarPriceInvalid = "Araba fiyatı geçersiz";
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ArabaHalaKirada = "Araç henüz kiradan dönmemiş. Kiralamaya uygun değil";
        public static string RentalListed = "Kiralama bilgisi eklendi";
        public static string RentalDeleted = "Kiralama iptal edildi";
        public static string RentalUpdated = "Kiralama bilgisi düzenlendi";
        //
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerUpdated = "Müşteri bilgisi düzenlendi";
        //
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserUpdated = "Kullanıcı bilgisi düzenlendi";
        //
        public static string CarUnavailable="araba şuanda müsait değil";
        public static string ImageLimitExceded="araba resim sınırına ulaşıldı";
        public static string Added="Eklendi";
        public static string CarImageDeleted="araba resmi silindi";
        public static string CarImageUpdated="araba resmi güncellendi";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string User2Added;
        public static string AccessTokenCreated;
        public static string SuccessfulLogin;
        public static string PasswordError;
        public static string UserNotFound;
        public static string UserRegistered;
        public static string UserAlreadyExists;
        public static string UserRegistered2;
    }
}
