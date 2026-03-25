# 🎓 Premium Student Registration Portal

A modern, high-performance full-stack application for managing student registrations, featuring a stunning **Glassmorphism UI** and a robust **.NET 10 + MongoDB** backend.

## 🚀 Teck Stack

### **Frontend**
- **Framework**: Angular 19 (Zoneless)
- **State Management**: Angular Signals (Computed & Effect)
- **Validation**: Zod (Schema-based validation)
- **Styling**: Vanilla CSS (Premium Glassmorphism Design System)
- **Reactivity**: Modern Angular Control Flow (`@if`, `@for`, `@let`)

### **Backend**
- **Framework**: .NET 10.0 Web API
- **Database**: MongoDB Atlas (Cloud)
- **Driver**: Native MongoDB C# Driver (`IMongoCollection`)
- **Documentation**: Swagger UI / OpenAPI 3.0

---

## ✨ Key Features

- 💎 **Premium Glass UI**: Deep purple-to-blue gradients with frosted glass cards and acrylic blur effects.
- 📱 **Fully Responsive**: Optimized for every device, from 320px mobile screens to large desktop monitors.
- ⚡ **Zoneless Performance**: Leverages Angular 19's zoneless change detection for ultra-fast rendering.
- 🛡️ **Zod Validation**: Robust client-side validation for essential fields (Name, Mobile, Email).
- 🔔 **Interactive Toasts**: Smooth glassmorphism success/warning notifications.
- 🔄 **Live Persistence**: Real-time synchronization with MongoDB Atlas.

---

## 🛠️ Getting Started

### **Prerequisites**
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js (v18+)](https://nodejs.org/)
- [MongoDB Atlas Account](https://www.mongodb.com/cloud/atlas)

### **1. Setup Backend (API)**
1. Navigate to the `API` directory:
   ```bash
   cd PremiumRegistration/API
   ```
2. Update `appsettings.json` with your MongoDB connection string.
3. Run the API:
   ```bash
   dotnet run
   ```
4. Access Swagger at `http://localhost:5200/swagger/index.html`.

### **2. Setup Frontend (Angular)**
1. Navigate to the `AngularClient` directory:
   ```bash
   cd PremiumRegistration/AngularClient
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm start
   ```
4. Open your browser at `http://localhost:4200`.

---

## 📱 Mobile-First Layout

The application uses a **mobile-first** approach:
- **Small Screens (< 1024px)**: Vertical stacked layout for better readability on tablets and mobile.
- **Large Screens (> 1024px)**: Side-by-side layout for maximum efficiency.
- **Tables**: Internal horizontal scrolling on mobile to prevent layout breakage.

---

## 📄 License

This project is part of a premium registration portfolio. Proprietary / Open Source.
