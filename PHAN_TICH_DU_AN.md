# 📊 Phân tích Dự án - Hệ thống Quản lý Sinh viên

> Tài liệu này dành cho các developer mới tham gia dự án

## 🎯 Tổng quan Dự án

**Tên dự án:** Hệ thống Quản lý Sinh viên (Student Management System)  
**Loại ứng dụng:** Desktop Application (Windows Forms)  
**Framework:** .NET 8.0  
**Ngôn ngữ:** C#  
**Kiến trúc:** 3-Layer Architecture (3 lớp)

---

## 🏗️ Kiến trúc Dự án

Dự án được tổ chức theo mô hình **3-Layer Architecture** (kiến trúc 3 lớp), giúp tách biệt rõ ràng các trách nhiệm:

```
┌─────────────────────────────────────┐
│   Presentation Layer (Giao diện)   │
│   - FormMain, UserControls         │
│   - Xử lý tương tác người dùng     │
└─────────────────────────────────────┘
              ↓ ↑
┌─────────────────────────────────────┐
│  BusinessLogic Layer (Logic nghiệp vụ)│
│   - StudentService                   │
│   - Tính toán GPA, thống kê         │
└─────────────────────────────────────┘
              ↓ ↑
┌─────────────────────────────────────┐
│   DataAccess Layer (Truy cập dữ liệu)│
│   - DataRepository (Singleton)      │
│   - ExcelHelper                      │
└─────────────────────────────────────┘
              ↓ ↑
┌─────────────────────────────────────┐
│         Models (Thực thể)            │
│   - Student, Score, Classroom, ...  │
└─────────────────────────────────────┘
```

### 1. **Models Layer** (Thực thể dữ liệu)
**Vị trí:** `/Models/`

Các class đại diện cho các thực thể trong hệ thống:

- **`Student.cs`**: Thông tin sinh viên
  - StudentID, FullName, DateOfBirth, Gender, Email, ClassID
  - Property `Age` tự động tính tuổi
  
- **`Score.cs`**: Điểm số
  - ProcessScore (điểm thành phần), FinalScore (điểm thi)
  - TotalScore tự động tính: `TP × 0.3 + Thi × 0.7`
  - Method `GetGrade()` trả về xếp loại (A, B+, B, C+, C, D+, D, F)
  
- **`Classroom.cs`**: Lớp học
- **`Subject.cs`**: Môn học (có số tín chỉ)
- **`Attendance.cs`**: Chuyên cần
- **`AuditLog.cs`**: Lịch sử thay đổi (ghi lại mọi thao tác CRUD)

### 2. **DataAccess Layer** (Truy cập dữ liệu)
**Vị trí:** `/DataAccess/`

#### **`DataRepository.cs`** - Quản lý dữ liệu
- **Pattern:** Singleton (chỉ có 1 instance duy nhất)
- **Lưu trữ:** In-memory (dữ liệu trong RAM, mất khi đóng app)
- **Các Collections:**
  ```csharp
  - List<Student> Students
  - List<Classroom> Classrooms
  - List<Subject> Subjects
  - List<Score> Scores
  - List<Attendance> Attendances
  - List<AuditLog> AuditLogs
  ```
- **Khởi tạo:** Tự động tạo dữ liệu mẫu khi khởi động (3 SV, 3 lớp, 4 môn)

#### **`ExcelHelper.cs`** - Xử lý Excel
- **Import:** Đọc danh sách sinh viên từ file Excel (.xlsx)
- **Export:** Xuất danh sách SV và bảng điểm ra Excel
- **Thư viện:** EPPlus 7.0.0

### 3. **BusinessLogic Layer** (Logic nghiệp vụ)
**Vị trí:** `/BusinessLogic/`

#### **`StudentService.cs`** - Các tính toán nghiệp vụ
Các method quan trọng:
- `CalculateGPA(string studentId)`: Tính GPA theo công thức: `Σ(Điểm TK × Tín chỉ) / Σ(Tín chỉ)`
- `CheckEligibility(string studentId)`: Kiểm tra SV có đủ điều kiện (GPA ≥ 5.0)
- `GetAttendanceRate(string studentId, string subjectId)`: Tính tỉ lệ chuyên cần
- `GetStudentsWithLowGPA(double threshold)`: Lấy danh sách SV có GPA thấp
- `GetGenderStatistics()`: Thống kê theo giới tính
- `GetClassStatistics()`: Thống kê theo lớp

### 4. **Presentation Layer** (Giao diện)
**Vị trí:** `/Presentation/`

#### **`FormMain.cs`** - Form chính
- Menu điều hướng bên trái (Dashboard, Quản lý SV, Quản lý Điểm, Cài đặt)
- Panel chính hiển thị UserControl tương ứng
- Xử lý animation cho menu (highlight button đang chọn)

#### **UserControls:**
- **`UCDashboard.cs`**: Dashboard thống kê tổng quan
- **`UCStudentManagement.cs`**: Quản lý sinh viên (CRUD, Import/Export, Filter)
- **`UCScoreManagement.cs`**: Quản lý điểm số và cảnh báo học vụ

#### **Forms (Dialog):**
- **`FormStudentDetail.cs`**: Form thêm/sửa sinh viên
- **`FormScoreDetail.cs`**: Form thêm/sửa điểm

---

## 📦 Dependencies (Thư viện)

Dự án sử dụng các NuGet packages sau:

```xml
<PackageReference Include="EPPlus" Version="7.0.0" />
<PackageReference Include="FontAwesome.Sharp" Version="6.2.1" />
<PackageReference Include="LiveChartsCore.SkiaSharpView.WinForms" Version="2.0.0-rc2" />
```

- **EPPlus**: Xử lý file Excel (import/export)
- **FontAwesome.Sharp**: Icon đẹp cho các button
- **LiveChartsCore**: Vẽ biểu đồ (chưa được sử dụng trong code hiện tại)

---

## 🔄 Luồng Dữ liệu (Data Flow)

### Ví dụ: Thêm sinh viên mới

```
1. User click "Thêm mới" 
   → UCStudentManagement.cs

2. Mở FormStudentDetail
   → User nhập thông tin → Click "Lưu"

3. FormStudentDetail gọi DataRepository.Instance.Students.Add()
   → DataRepository.cs

4. Ghi AuditLog
   → DataRepository.AddAuditLog()

5. Refresh UI
   → UCStudentManagement.LoadStudents()
```

### Ví dụ: Tính GPA

```
1. UCDashboard cần hiển thị GPA
   → Gọi StudentService.CalculateGPA(studentId)

2. StudentService truy vấn DataRepository
   → Lấy danh sách Score của SV
   → Lấy thông tin Subject (tín chỉ)

3. Tính toán và trả về kết quả
   → GPA = Σ(Điểm TK × Tín chỉ) / Σ(Tín chỉ)
```

---

## 🗂️ Cấu trúc Thư mục Chi tiết

```
QuanLySinhVienCS/
│
├── Models/                          # Thực thể dữ liệu
│   ├── Student.cs                   # Sinh viên
│   ├── Score.cs                     # Điểm số
│   ├── Classroom.cs                 # Lớp học
│   ├── Subject.cs                   # Môn học
│   ├── Attendance.cs                # Chuyên cần
│   └── AuditLog.cs                  # Lịch sử thay đổi
│
├── DataAccess/                      # Truy cập dữ liệu
│   ├── DataRepository.cs            # Repository pattern (Singleton)
│   └── ExcelHelper.cs               # Xử lý Excel
│
├── BusinessLogic/                   # Logic nghiệp vụ
│   └── StudentService.cs            # Tính toán GPA, thống kê
│
├── Presentation/                    # Giao diện
│   ├── FormMain.cs                  # Form chính
│   ├── FormMain.Designer.cs         # Designer của FormMain
│   │
│   ├── Forms/                       # Các form dialog
│   │   ├── FormStudentDetail.cs
│   │   ├── FormStudentDetail.Designer.cs
│   │   ├── FormScoreDetail.cs
│   │   └── FormScoreDetail.Designer.cs
│   │
│   └── UserControls/                # Các UserControl
│       ├── UCDashboard.cs
│       ├── UCDashboard.Designer.cs
│       ├── UCStudentManagement.cs
│       ├── UCStudentManagement.Designer.cs
│       ├── UCScoreManagement.cs
│       └── UCScoreManagement.Designer.cs
│
├── SampleData/                      # Dữ liệu mẫu
│   └── StudentTemplate.md           # Mẫu file Excel
│
├── Program.cs                        # Entry point
├── StudentManagement.csproj         # Project file
│
└── Tài liệu/
    ├── README.md                    # Tổng quan dự án
    ├── DOCUMENTATION.md             # Tài liệu chi tiết (619 dòng)
    ├── TAI_LIEU_HUONG_DAN.md        # Hướng dẫn sử dụng
    ├── QUICK_START.md               # Hướng dẫn nhanh
    └── PHAN_TICH_DU_AN.md           # File này
```

---

## 🔑 Design Patterns Sử dụng

### 1. **Singleton Pattern**
**File:** `DataRepository.cs`

```csharp
private static DataRepository? _instance;
public static DataRepository Instance
{
    get
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new DataRepository();
            }
        }
        return _instance;
    }
}
```

**Mục đích:** Đảm bảo chỉ có 1 instance duy nhất của DataRepository trong toàn bộ ứng dụng.

### 2. **Repository Pattern**
**File:** `DataRepository.cs`

Tập trung tất cả truy cập dữ liệu vào một nơi, dễ dàng thay đổi cách lưu trữ sau này (từ in-memory sang database).

---

## 📊 Công thức Tính toán

### 1. **Điểm Tổng kết (TotalScore)**
```
Điểm TK = Điểm Thành phần × 0.3 + Điểm Thi × 0.7
```
**File:** `Models/Score.cs` - Method `CalculateTotalScore()`

### 2. **GPA (Grade Point Average)**
```
GPA = Σ(Điểm TK × Số tín chỉ) / Σ(Số tín chỉ)
```
**File:** `BusinessLogic/StudentService.cs` - Method `CalculateGPA()`

### 3. **Xếp loại**
| Điểm TK | Xếp loại |
|---------|----------|
| ≥ 8.5   | A        |
| ≥ 8.0   | B+       |
| ≥ 7.0   | B        |
| ≥ 6.5   | C+       |
| ≥ 5.5   | C        |
| ≥ 5.0   | D+       |
| ≥ 4.0   | D        |
| < 4.0   | F        |

**File:** `Models/Score.cs` - Method `GetGrade()`

### 4. **Tỉ lệ Chuyên cần**
```
Tỉ lệ = (Số buổi có mặt / Tổng số buổi) × 100%
```
**File:** `BusinessLogic/StudentService.cs` - Method `GetAttendanceRate()`

---

## 🎨 Giao diện (UI)

### Màu sắc chủ đạo:
- **Dashboard:** `Color.FromArgb(41, 128, 185)` (Xanh dương)
- **Quản lý SV:** `Color.FromArgb(46, 213, 115)` (Xanh lá)
- **Quản lý Điểm:** `Color.FromArgb(255, 159, 67)` (Cam)
- **Cài đặt:** `Color.FromArgb(108, 92, 231)` (Tím)

### Icon:
- Sử dụng **FontAwesome.Sharp** cho các icon button

---

## 🔍 Các Tính năng Chính

### ✅ Đã hoàn thành:
1. **CRUD Sinh viên** (Thêm, Sửa, Xóa, Xem)
2. **CRUD Điểm số**
3. **Import/Export Excel** (Sinh viên và Bảng điểm)
4. **Dashboard thống kê** (Tổng số SV, tỉ lệ nam/nữ, SV nợ môn, chuyên cần)
5. **Bộ lọc nâng cao** (Theo tên, lớp, giới tính, GPA)
6. **Cảnh báo học vụ** (SV có GPA thấp, chuyên cần kém)
7. **Audit Log** (Ghi lại mọi thay đổi)

### 🚧 Chưa hoàn thành (Roadmap):
- [ ] Kết nối database thực (hiện tại chỉ lưu trong RAM)
- [ ] Biểu đồ trực quan (LiveCharts đã cài nhưng chưa dùng)
- [ ] Quản lý chuyên cần chi tiết
- [ ] In báo cáo trực tiếp
- [ ] Đăng nhập/Phân quyền
- [ ] Gửi email cảnh báo
- [ ] Giao diện xem Audit Log

---

## 🚀 Cách Chạy Dự án

### Yêu cầu:
- .NET 8.0 SDK
- Windows 10/11
- Visual Studio 2022 hoặc VS Code (khuyến nghị)

### Các bước:

1. **Restore packages:**
   ```bash
   dotnet restore
   ```

2. **Build project:**
   ```bash
   dotnet build
   ```

3. **Chạy ứng dụng:**
   ```bash
   dotnet run
   ```

---

## 📝 Coding Conventions

### Naming:
- **Class:** PascalCase (ví dụ: `StudentService`, `DataRepository`)
- **Method:** PascalCase (ví dụ: `CalculateGPA`, `GetStudentsWithLowGPA`)
- **Property:** PascalCase (ví dụ: `StudentID`, `FullName`)
- **Variable:** camelCase (ví dụ: `studentId`, `totalScore`)
- **Private field:** camelCase với prefix `_` (ví dụ: `_instance`, `_repository`)

### File Organization:
- Mỗi class một file
- File Designer (.Designer.cs) đi kèm với file Form/UserControl

---

## 🔧 Các Điểm Cần Lưu Ý

### 1. **Dữ liệu In-Memory**
⚠️ **Quan trọng:** Dữ liệu hiện tại chỉ lưu trong RAM. Khi đóng ứng dụng, tất cả dữ liệu sẽ mất!

**Giải pháp tạm thời:** Export ra Excel trước khi đóng app.

**Giải pháp tương lai:** Kết nối database (SQL Server, SQLite, PostgreSQL, ...)

### 2. **Singleton Pattern**
DataRepository sử dụng Singleton, nên mọi nơi trong code đều truy cập cùng một instance:
```csharp
var repo = DataRepository.Instance;
```

### 3. **Audit Log**
Mọi thao tác CRUD đều được ghi vào AuditLog. Hiện tại chưa có giao diện xem log, nhưng có thể truy cập qua:
```csharp
DataRepository.Instance.AuditLogs
```

### 4. **Excel Import Format**
File Excel import phải có đúng 6 cột theo thứ tự:
1. Mã SV
2. Họ tên
3. Ngày sinh (dd/MM/yyyy)
4. Giới tính
5. Email
6. Mã Lớp

---

## 🐛 Debugging Tips

### 1. **Xem dữ liệu trong DataRepository:**
```csharp
// Trong code, thêm breakpoint và inspect:
var repo = DataRepository.Instance;
var students = repo.Students; // Xem danh sách SV
var scores = repo.Scores;     // Xem danh sách điểm
```

### 2. **Xem Audit Log:**
```csharp
var logs = DataRepository.Instance.AuditLogs;
foreach (var log in logs)
{
    Console.WriteLine(log.ToString());
}
```

### 3. **Kiểm tra Excel Import:**
- Đặt breakpoint trong `ExcelHelper.LoadStudents()`
- Kiểm tra từng dòng được đọc

---

## 📚 Tài liệu Tham khảo

1. **README.md**: Tổng quan dự án, kiến trúc
2. **DOCUMENTATION.md**: Tài liệu chi tiết 619 dòng (hướng dẫn sử dụng)
3. **TAI_LIEU_HUONG_DAN.md**: Hướng dẫn sử dụng ngắn gọn
4. **QUICK_START.md**: Hướng dẫn nhanh 5 phút

---

## 🎯 Hướng Dẫn Cho Dev Mới

### Tuần 1: Làm quen
1. ✅ Đọc file này (PHAN_TICH_DU_AN.md)
2. ✅ Đọc README.md để hiểu tổng quan
3. ✅ Chạy ứng dụng và thử các tính năng
4. ✅ Đọc code các file Models để hiểu cấu trúc dữ liệu
5. ✅ Trace luồng dữ liệu khi thêm 1 sinh viên mới

### Tuần 2: Hiểu sâu
1. ✅ Đọc code DataRepository.cs (hiểu Singleton pattern)
2. ✅ Đọc code StudentService.cs (hiểu logic nghiệp vụ)
3. ✅ Đọc code ExcelHelper.cs (hiểu import/export)
4. ✅ Đọc code các UserControl (hiểu cách UI hoạt động)

### Tuần 3: Bắt đầu code
1. ✅ Fix bug nhỏ (nếu có)
2. ✅ Thêm tính năng nhỏ (ví dụ: thêm validation)
3. ✅ Refactor code (nếu cần)
4. ✅ Viết unit test (nếu có thời gian)

---

## 💡 Gợi Ý Cải thiện

### Ngắn hạn:
1. Thêm validation cho email format
2. Thêm confirmation dialog khi xóa
3. Thêm tooltip cho các button
4. Cải thiện error handling

### Dài hạn:
1. **Kết nối Database:** Thay thế in-memory bằng SQL Server/SQLite
2. **Unit Tests:** Viết test cho BusinessLogic layer
3. **Dependency Injection:** Sử dụng DI container (Microsoft.Extensions.DependencyInjection)
4. **MVVM Pattern:** Có thể cân nhắc chuyển sang MVVM nếu dự án lớn hơn
5. **Async/Await:** Sử dụng async cho các thao tác I/O (Excel, Database)

---

## 📞 Liên hệ & Hỗ trợ

Nếu có thắc mắc:
1. Đọc các file tài liệu trong thư mục gốc
2. Xem code comments trong các file .cs
3. Trace code bằng debugger

---

**Chúc bạn làm việc hiệu quả với dự án! 🚀**

*Tài liệu này được tạo tự động để giúp dev mới nhanh chóng làm quen với dự án.*

