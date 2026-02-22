# MyShop - Online Store Project

A simple and professional e-commerce project built with **ASP.NET Core 8 (Razor Pages + MVC)** for managing products, shopping cart, and admin panel.

---

## 🚀 Features

### User (Front-End)
- View products with details (name, price, image, availability)
- Add products to the shopping cart
- Manage product quantity in the cart
- Display total price and stock availability
- Test checkout (no real payment gateway)

### Admin Panel
- **Razor Pages** for product CRUD operations
- Add, edit, and delete products
- Manage product images
- Manage stock quantity and product prices
- Display products in a modern table layout

### Project Architecture
- **Front-End:** MVC with Razor Views
- **Admin Panel:** Razor Pages
- **Database:** SQL Server with EF Core 8
- **Models:** Product, Item, Order, OrderDetail, Users
- **Authentication:** Cookie Authentication

---

## 🛠 Tools and Technologies
- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- Bootstrap 5 (CSS)
- Visual Studio 2022

---

## ⚙️ Installation & Running

1. Clone the repository:
```bash
git clone https://github.com/HananehDev/Shop.git
cd MyShop
```

📝 Important Notes

Product images are stored in /wwwroot/images/ and the filename is based on the product Id.

Admin panel uses Razor Pages for fast and form-based CRUD operations.

Front-End is built with MVC for dynamic product display and shopping cart functionality.

User authentication uses cookies (valid for 10 days)

---

🧩 Development Tips

For new pages in the Admin panel, use Razor Pages.

When adding new tables or models, always create a Migration:

dotnet ef migrations add AddNewTable
dotnet ef database update

---

📌 Project Status

Version: 1.0

Status: Functional and ready for testing

Ready for delivery to client

---

Built with ❤️ by Hananeh
