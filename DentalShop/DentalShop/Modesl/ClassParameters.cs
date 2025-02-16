using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xamarin.Forms;

namespace DentalShop
{
    public class UserEntity
    {
        public string UserId { get; set; }
        public String UserName { get; set; }
        public String UserEmail { get; set; }
        public String UserPassword { get; set; }
        public String UserPhone { get; set; }
        public String UserPhoto { get; set; }


        public UserEntity()
        {

        }
    }

    public class LogInUser
    {
        public String phone { get; set; }
        public String password { get; set; }
        public String UserId { get; set; }
        public LogInUser()
        {

        }
    }

    public class SendCode
    {
        public String UserEmail { get; set; }


        public SendCode()
        {

        }
    }



    public class Prouduct
    {
        public ImageSource MainPhoto { get; set; }
        public bool ImgDiscountEnable { get; set; }
        public bool LBDiscountEnable { get; set; }
        public String LBDiscount { get; set; }
        public string Price { get; set; }
        public String LBSecondPrice { get; set; }
        public bool LBSecondPriceEnable { get; set; }
        public String Name { get; set; }
        //public ImageSource FirstPhoto { get; set; }
        //public ImageSource SecondPhoto { get; set; }
        //public ImageSource ThirdPhoto { get; set; }
        //public ImageSource FourthPhoto { get; set; }
        //public ImageSource FifthPhoto { get; set; }
        public ImageSource MarcketPhoto { get; set; }
        public ImageSource FavoritesPhoto { get; set; }
        public string index { get; set; }
        public bool ImgDiscountBarEnable { get; set; }
        public string Favorite { get; set; }
        public string Marcket { get; set; }
        public string Type { get; set; }
        public string ListLocation { get; set; }
        public string LBID { get; set; }
        public Prouduct()
        { }
    }


    public class ProuductEntity
    {
        public int ProductID { get; set; }
        public string ProuductName { get; set; }
        public string ProuductDescription { get; set; }
        public string MadeIn { get; set; }
        public String Price { get; set; }
        public string Amount { get; set; }
        public String EXDate { get; set; }
        public String Others { get; set; }
        public String FirstYear { get; set; }
        public String SecondYear { get; set; }
        public string ThirdYear { get; set; }
        public string FourthYear { get; set; }
        public string FifthYear { get; set; }
        public string Teeth { get; set; }
        public string Clothes { get; set; }
        public string Type { get; set; }
        public string Discount { get; set; }
        public String FirstPhoto { get; set; }
        public String SecondPhoto { get; set; }
        public string ThirdPhoto { get; set; }
        public string FourthPhoto { get; set; }
        public string FifthPhoto { get; set; }
        public string SixthPhoto { get; set; }
        public string Size { get; set; }
        public string Guarantee { get; set; }

        public ProuductEntity()
        { }
    }


    public class GetProuduct
    {
        public string SearchText { get; set; }
        public String Type { get; set; }
        public string AlphaBit { get; set; }


        public GetProuduct()
        {

        }
    }

    public class GetStudentProuduct
    {
        public string SearchText { get; set; }
        public String Type { get; set; }
        public string AlphaBit { get; set; }
        public string FirstYear { get; set; }
        public string SecondYear { get; set; }
        public string ThirdYear { get; set; }
        public string FourthYear { get; set; }
        public string FifthYear { get; set; }
        public string Teeth { get; set; }
        public string Clothes { get; set; }
        public string Others { get; set; }
        public GetStudentProuduct()
        {

        }
    }


    public class AddFavorite
    {
        public string ProuductID { get; set; }
        public String UserID { get; set; }

        public AddFavorite()
        {

        }
    }

    public class GetDelivery
    {
        public string Cairo { get; set; }
        public String Out { get; set; }

        public GetDelivery()
        {

        }
    }

    public class CartObject
    {
        public ImageSource ImgProuduct { get; set; }
        public String LBName { get; set; }
        public string LBPrice { get; set; }
        public String LBTotalPrice { get; set; }
        public String LBAmount { get; set; }
        public string index { get; set; }
        public string LBID { get; set; }
        public CartObject()
        { }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string OrderTime { get; set; }
        public string OrderStatus { get; set; }
        public string OrderAcceptTime { get; set; }
        public string OrderPrice { get; set; }
        public string OrderLocation { get; set; }
        public string OrderPhone { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryFees { get; set; }
        public string OrderExcuteTime { get; set; }
        public string OrderCompleteTime { get; set; }
        public string UserAvilableTime { get; set; }
        public string OrderAmount { get; set; }
        public string OrderGovernorate { get; set; }
        public OrderList [] OrderProuductList { get; set; }
        public Order ()
        { }
    }
    public class OrderList
    {
        public int OrderId { get; set; }
        public int ProuductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
 
        public OrderList()
        { }
    }


    public class OrderViewObject
    {
        public bool ImgEdit { get; set; }
        public String LBOrderID { get; set; }
        public string LBPrice { get; set; }
        public String LBDelivery { get; set; }
        public String LBAmount { get; set; }
        public string index { get; set; }
        public string LBDate { get; set; }
        public string LBTotalPrice { get; set; }
        public OrderViewObject()
        { }
    }

    public class NotificationViewObject
    {
        public String LBOrderID { get; set; }
        public string LBPrice { get; set; }
        public String LBDelivery { get; set; }
        public String LBAmount { get; set; }
        public string LBNotificationText { get; set; }
        public NotificationViewObject()
        { }
    }
    public class Notifications
    {
        public string LBNotificationText { get; set; }
        public string Time { get; set; }
        public Notifications()
        { }
    }
    public class LastNotificationObject
    {
        public String LastNotification { get; set; }
        public string Id { get; set; }
        public LastNotificationObject()
        { }
    }
    public class LaterNotification
    {
        public String Name { get; set; }
        public string Id { get; set; }
        public LaterNotification()
        { }
    }
}