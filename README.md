# ClearView-
 ClearView – Backend System (ASP.NET Core Web API)
 Overview:
I developed the backend of a vision-care application using ASP.NET Core, focused on building a secure, scalable, and modular architecture. The system handles users (patients), doctors, appointments, vision

Modules I Developed:
 Authentication & Authorization:
•	Implemented secure user registration and login using JWT Tokens.
•	Applied role-based access control for Patients, Doctors, and Admins.
•	Used BCrypt.Net to hash passwords securely.
•	Enabled Google & Facebook login integration (OAuth-ready design).
  User & Doctor Management:
•	Created separate controllers for users and doctors.
•	Built APIs to:
o	View and update user/doctor profile (authenticated user only).
o	Get doctor details by ID.
o	List all available doctors.
•	Applied claims-based identity to fetch user data without sending IDs manually.
   Appointments:
•	Users can book, edit, or cancel appointments with doctors.
•	Doctors can view appointments related to them.
•	Prevented multiple bookings at the same time.
•	Ensured validations and proper error handling.
    Other Features:
•	Linked users with cities, countries, and clinics using lookup tables.
•	Designed all relationships with Entity Framework Core including:
o	Inheritance (Doctor inherits from User).
o	Optional relationships (e.g., User may or may not be linked to a Doctor).
•	Configured CORS, Swagger, and secure environment-based settings.
Tech Stack:
•	Framework: ASP.NET Core Web API
•	ORM: Entity Framework Core
•	Auth: JWT + Roles + Claims
•	Database: SQL Server
•	Documentation: Swagger
•	Security: Password Hashing (BCrypt), Token Validation
•	Design Pattern: Layered Architecture (Controllers → Services → Repositories/DbContext)

My Role:
"I was fully responsible for designing and implementing the backend system. I created and connected all APIs with the frontend team, handled authentication, database structure, and ensured the entire system was secure, maintainable, and scalable."
