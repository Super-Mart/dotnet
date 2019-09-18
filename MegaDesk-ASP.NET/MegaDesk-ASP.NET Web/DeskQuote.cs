using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_ASP.NET_Web
{
    public class DeskQuote
    {
        static int[,] rushorderprice = GetRushOrder();
        //Constants 
        const decimal BASE_DESK_PRICE = 200.00M;
        const decimal SURFACE_AREA_COST = 1.00M;
        const decimal DRAWER_COST = 50.00M;
        const decimal OAK_COST = 200.00M;
        const decimal LAMINATE_COST = 100.00M;
        const decimal PINE_COST = 50.00M;
        const decimal ROSEWOOD_COST = 300.00M;
        const decimal VENEER_COST = 125.00M;
        decimal RUSH_3DAY_LESS_THAN_1000 = rushorderprice[0, 0];
        decimal RUSH_3DAY_1000_TO_2000 = rushorderprice[0, 1];
        decimal RUSH_3DAY_GREATER_THAN_2000 = rushorderprice[0, 2];
        decimal RUSH_5DAY_LESS_THAN_1000 = rushorderprice[1, 0];
        decimal RUSH_5DAY_1000_TO_2000 = rushorderprice[1, 1];
        decimal RUSH_5DAY_GREATER_THAN_2000 = rushorderprice[1, 2];
        decimal RUSH_7DAY_LESS_THAN_1000 = rushorderprice[2, 0];
        decimal RUSH_7DAY_1000_TO_2000 = rushorderprice[2, 1];
        decimal RUSH_7DAY_GREATER_THAN_2000 = rushorderprice[2, 2];

        // all of rushing  days will be replaced in arrays and should be commented out
        public enum Delivery
        {
            Days3,
            Days5,
            Days7,
            Days14
        }

        public Desk Desk { get; set; }
        public string CustomerName { get; set; }
        public DateTime QuoteDate { get; set; }
        public Delivery DeliveryType { get; set; }
        public Decimal PriceAmount { get; set; }

        //Methods and the calculation of the new quote.
        public decimal GetQuote()
        {
            var Total = 200;
            var SurfaceArea = this.Desk.Width * this.Desk.Depth;
            //var DrawersAmount = this.Desk.NumberOfDrawers * 50;
            //

            if (SurfaceArea > 1000)
            {
                Total += (int)SurfaceArea; // declaring int to indicate the total amount in int number 
            }

            //get the price of each desk
            //switch (this.Desk.SurfaceMaterial) // goes to desk and to surfacematrial // this would get the newdeskQuote infor
            //{
            //    case Desk.Surface.Oak:
            //        Total += 200; // Total is 200 and adds up the price for the oaks and totaling them up
            //        break;

            //    case Desk.Surface.Laminate:
            //        Total += 100;
            //        break;

            //    case Desk.Surface.Pine:
            //        Total += 50;
            //        break;

            //    case Desk.Surface.Rosewood:
            //        Total += 300;
            //        break;

            //    case Desk.Surface.Veneer:
            //        Total += 125;
            //        break;
            //}

            switch (this.DeliveryType)
            {
                case Delivery.Days3:
                    if (SurfaceArea < 1000)
                    {
                        Total += 60;
                    }
                    else if (SurfaceArea >= 1000 && SurfaceArea <= 2000)
                    {
                        Total += 70;
                    }
                    else
                    {
                        Total += 80;
                    }
                    break;

                case Delivery.Days5:
                    if (SurfaceArea < 1000)
                    {
                        Total += 40;
                    }
                    else if (SurfaceArea >= 1000 && SurfaceArea <= 2000)
                    {
                        Total += 50;
                    }
                    else
                    {
                        Total += 60;
                    }
                    break;

                case Delivery.Days7:
                    if (SurfaceArea < 1000)
                    {
                        Total += 30;
                    }
                    else if (SurfaceArea >= 1000 && SurfaceArea <= 2000)
                    {
                        Total += 35;
                    }
                    else
                    {
                        Total += 40;
                    }
                    break;

                default:
                    Total += 0;
                    break;
            }
            return Total;
        }

        public static int[,] GetRushOrder()
        {
            try
            {
                string[] rushOrderPrice1 = File.ReadAllLines(@"rushOrderPrices.txt");
                int[,] rushOrderPrice2 = new int[3, 3];
                int rushOrderPrice3 = 0;

                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        rushOrderPrice2[i, j] = Int32.Parse(rushOrderPrice1[rushOrderPrice3]);
                        rushOrderPrice3++;
                    }
                }

                return rushOrderPrice2;
            }

            catch
            {
                return null;
            }
        }
    }

}