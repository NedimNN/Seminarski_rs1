using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Repository;
using Online_Rezervacija_Restorana.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Rezervacija_Restorana.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly ITableRepository tableRepository;

        public OrderController(
            IOrderDetailRepository orderDetailRepository,
            IReservationRepository reservationRepository,
            IOrderRepository orderRepository,
            ITableRepository tableRepository

        )
        {
            this.orderDetailRepository = orderDetailRepository;
            this.reservationRepository = reservationRepository;
            this.orderRepository = orderRepository;
            this.reservationRepository = reservationRepository;
            this.tableRepository = tableRepository;


        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddOrder(int id)
        {
            Reservation reserv = reservationRepository.GetReservation(id);
            Table table = tableRepository.GetTable(reserv.TableID);
            AddOrderVM o = new AddOrderVM
            {
                reservationId = id,
                orderMeal = (List<SelectListItem>)orderDetailRepository.GetMealsForSelectList(table.RestaurantId)
            };

            return View(o);
        }
        public IActionResult ShowOrder(int id)
        {
            var order = orderRepository.GetOrderByReservation(id);
            if(order == null)
            {
                return Redirect("~/Reservation/UserReservation");
            }
            OrderDetail orderD = orderDetailRepository.GetOrderDetailsByOrder(order.ID);
            if (orderD == null)
            {
                return Redirect("~/Reservation/UserReservation");
            }
            ShowOrderVM o = new ShowOrderVM
            {
                orderAller = orderD.Allergies,
                orderDesc = orderD.Description,
                reservationId = order.ReservationID,
                meal = orderD.Meals.FirstOrDefault()

            };
            
            return View(o);
        }

    }
}
