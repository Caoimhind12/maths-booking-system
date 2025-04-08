# 📚 Maths Department Booking System  
*A tutoring schedule management platform for teachers and students*

---

## 🌟 Key Features  
| Feature | Description |  
|---------|-------------|  
| **Role-Based Access** | Teachers create slots, students book sessions |  
| **Real-Time Availability** | Dynamic timeslot updates with `SpotsTaken` tracking |  
| **Responsive UI** | Bootstrap-powered works on all devices |  
| **Secure Auth** | ASP.NET Identity + OAuth (Google/Microsoft) |  

---

## 🛠️ Tech Stack  
**Frontend**  
- ASP.NET MVC 5 | Razor Views | jQuery 3.3.1 | Bootstrap 4  

**Backend**  
- C# | Entity Framework 6 (Database-First) | OWIN  

**Database**  
- SQL Server | Tables: `Teacher`, `Lesson`, `Day`, `Timeslot`  

---

## 🗃️ Database Schema  
### Core Tables  
```sql
-- Simplified schema preview
CREATE TABLE Teacher (
    TeacherID INT PRIMARY KEY IDENTITY,
    Forename NVARCHAR(50),
    Email NVARCHAR(50) UNIQUE
);

CREATE TABLE Lesson (
    LessonID INT PRIMARY KEY IDENTITY,
    TeacherID INT FOREIGN KEY REFERENCES Teacher(TeacherID),
    Available BIT DEFAULT 1,
    SpotsTaken INT DEFAULT 0
);
