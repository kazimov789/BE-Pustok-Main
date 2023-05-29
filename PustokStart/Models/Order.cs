﻿using System.ComponentModel.DataAnnotations;
using PustokStart.Enums;

namespace PustokStart.Models
{
	public class Order
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string FullName { get; set; }

		[MaxLength(20)]
		public string Phone { get; set; }

		[MaxLength(200)]
		public string Address { get; set; }
		[Required]
		[MaxLength(100)]
		public string Email { get; set; }
		[MaxLength(200)]
		public string Note { get; set; }
		public string AppUserId {get; set;}
		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		public DateTime CreatedAt {  get; set; }
		public OrderStatus Status { get; set; }
		public AppUser AppUser { get; set; }	

	}
}
