# 📚 Tài liệu Hướng dẫn Sử dụng - Hệ thống Quản lý Sinh viên

## Mục lục
1. [Giới thiệu](#giới-thiệu)
2. [Yêu cầu hệ thống](#yêu-cầu-hệ-thống)
3. [Cài đặt](#cài-đặt)
4. [Khởi động ứng dụng](#khởi-động-ứng-dụng)
5. [Hướng dẫn sử dụng chi tiết](#hướng-dẫn-sử-dụng-chi-tiết)
6. [Các tính năng nâng cao](#các-tính-năng-nâng-cao)
7. [Xử lý lỗi thường gặp](#xử-lý-lỗi-thường-gặp)
8. [FAQ](#faq)

---

## Giới thiệu

**Hệ thống Quản lý Sinh viên** là ứng dụng desktop được xây dựng bằng WinForms (.NET 8) với kiến trúc 3 lớp (3-Layer Architecture), giúp quản lý thông tin sinh viên, điểm số, và theo dõi học vụ một cách hiệu quả.

### Tính năng chính:
- ✅ Quản lý thông tin sinh viên (CRUD)
- ✅ Quản lý điểm số và tính GPA tự động
- ✅ Dashboard thống kê trực quan
- ✅ Import/Export Excel hàng loạt
- ✅ Bộ lọc và tìm kiếm nâng cao
- ✅ Cảnh báo học vụ tự động
- ✅ Audit Log (Ghi lại lịch sử thay đổi)

---

## Yêu cầu hệ thống

### Phần mềm cần thiết:
- **.NET 8.0 SDK** hoặc cao hơn
  - Tải tại: https://dotnet.microsoft.com/download/dotnet/8.0
- **Windows 10/11** (64-bit)
- **Microsoft Excel** (tùy chọn, để xem file export)

### Cấu hình tối thiểu:
- RAM: 4GB
- Ổ cứng: 500MB trống
- Màn hình: 1280x720 trở lên

---

## Cài đặt

### Bước 1: Kiểm tra .NET SDK
Mở Command Prompt hoặc PowerShell và chạy:
```bash
dotnet --version
```
Kết quả phải là `8.0.x` hoặc cao hơn.

### Bước 2: Clone/Tải dự án
Nếu bạn đã có mã nguồn, chuyển đến thư mục dự án:
```bash
cd C:\Users\longdh\workspace\csharp
```

### Bước 3: Restore NuGet Packages
```bash
dotnet restore
```
Lệnh này sẽ tải về các thư viện cần thiết:
- EPPlus (xử lý Excel)
- FontAwesome.Sharp (icons)
- LiveChartsCore (biểu đồ)

### Bước 4: Build dự án
```bash
dotnet build
```
Nếu build thành công, bạn sẽ thấy thông báo: `Build succeeded.`

---

## Khởi động ứng dụng

### Cách 1: Chạy trực tiếp từ source code
```bash
dotnet run
```

### Cách 2: Chạy file .exe đã build
```bash
# Build release
dotnet build -c Release

# File .exe nằm tại:
# bin\Release\net8.0-windows\StudentManagement.exe
```

### Giao diện khi khởi động:
- **Menu bên trái**: Các chức năng chính (Dashboard, Quản lý Sinh viên, Quản lý Điểm, Cài đặt)
- **Panel chính**: Hiển thị nội dung tương ứng với menu được chọn
- **Thanh tiêu đề**: Có nút Minimize, Maximize, Close

---

## Hướng dẫn sử dụng chi tiết

### 🏠 1. Dashboard (Trang chủ)

**Mục đích**: Xem tổng quan tình hình học tập của toàn bộ sinh viên.

#### Các thông tin hiển thị:

1. **Thẻ thống kê** (4 thẻ màu):
   - **Tổng số sinh viên**: Số lượng sinh viên trong hệ thống
   - **Sinh viên nợ môn**: Số SV có GPA < 5.0 (màu đỏ)
   - **Tỉ lệ chuyên cần**: % trung bình (màu xanh lá)
   - **Tỉ lệ giới tính**: % Nam và % Nữ (màu tím)

2. **Bảng thống kê theo lớp**:
   - Hiển thị số lượng sinh viên của từng lớp
   - Cột: Lớp, Số_sinh_viên

3. **Bảng cảnh báo học vụ**:
   - Danh sách 10 sinh viên đầu tiên có GPA thấp
   - Hiển thị: Mã SV, Họ tên, Lớp, GPA

#### Cách sử dụng:
- Dashboard tự động load khi mở ứng dụng
- Click menu **"Trang chủ"** để quay lại Dashboard
- Dữ liệu tự động cập nhật khi có thay đổi

---

### 👥 2. Quản lý Sinh viên

**Mục đích**: Thêm, sửa, xóa, tìm kiếm thông tin sinh viên.

#### 2.1. Thêm sinh viên mới

**Các bước:**
1. Click nút **"Thêm mới"** (màu xanh lá, góc trên bên trái)
2. Form **"Thêm sinh viên mới"** sẽ hiện ra
3. Điền thông tin:
   - **Mã SV** ⭐ (bắt buộc): Ví dụ: SV001, SV002, ...
   - **Họ tên** ⭐ (bắt buộc): Tên đầy đủ
   - **Ngày sinh**: Chọn từ DatePicker
   - **Giới tính** ⭐: Chọn "Nam" hoặc "Nữ"
   - **Email**: Địa chỉ email (không bắt buộc nhưng nên có)
   - **Lớp** ⭐: Chọn từ dropdown (phải có lớp trong hệ thống)
4. Click **"Lưu"** để thêm hoặc **"Hủy"** để bỏ qua

**Lưu ý:**
- Mã SV phải là duy nhất (không trùng với SV đã có)
- Nếu Mã SV trùng, hệ thống sẽ báo lỗi
- Email phải có ký tự "@" nếu nhập

#### 2.2. Sửa thông tin sinh viên

**Các bước:**
1. Trong bảng danh sách, **click vào dòng** sinh viên cần sửa (dòng sẽ được highlight)
2. Click nút **"Sửa"** (màu xanh dương)
3. Form **"Sửa thông tin sinh viên"** hiện ra với dữ liệu đã điền sẵn
4. Chỉnh sửa các trường cần thiết (trừ **Mã SV** - không thể sửa)
5. Click **"Lưu"** để lưu thay đổi

**Lưu ý:**
- Mã SV bị khóa (ReadOnly) khi ở chế độ sửa
- Tất cả thay đổi được ghi vào Audit Log

#### 2.3. Xóa sinh viên

**Các bước:**
1. Chọn sinh viên trong bảng (click vào dòng)
2. Click nút **"Xóa"** (màu đỏ)
3. Hộp thoại xác nhận hiện ra: **"Bạn có chắc chắn muốn xóa sinh viên này?"**
4. Click **"Yes"** để xóa hoặc **"No"** để hủy

**Cảnh báo:**
- ⚠️ Xóa sinh viên sẽ xóa tất cả điểm số liên quan
- Hành động này không thể hoàn tác
- Nên export dữ liệu trước khi xóa

#### 2.4. Import từ Excel

**Mục đích**: Thêm nhiều sinh viên cùng lúc từ file Excel.

**Các bước:**
1. Chuẩn bị file Excel với cấu trúc:
   ```
   | Mã SV | Họ tên | Ngày sinh | Giới tính | Email | Mã Lớp |
   |-------|--------|----------|-----------|-------|--------|
   | SV004 | Nguyễn Văn A | 15/03/2001 | Nam | a@email.com | CNTT1 |
   | SV005 | Trần Thị B | 20/07/2000 | Nữ | b@email.com | CNTT2 |
   ```
   - Dòng 1: Header (bắt buộc)
   - Từ dòng 2: Dữ liệu sinh viên
   - Định dạng ngày: dd/MM/yyyy hoặc MM/dd/yyyy

2. Click nút **"Import Excel"** (màu tím)
3. Chọn file Excel (.xlsx hoặc .xls)
4. Hệ thống sẽ:
   - Đọc file và hiển thị số lượng import thành công
   - Bỏ qua các dòng lỗi (không đúng format)
   - Bỏ qua sinh viên có Mã SV trùng (không ghi đè)

**Ví dụ kết quả:**
```
Import thành công 15 sinh viên!
```

**Lưu ý:**
- File Excel phải có đúng 6 cột theo thứ tự trên
- Mã Lớp phải tồn tại trong hệ thống (CNTT1, CNTT2, KT1, ...)
- Nếu thiếu dữ liệu ở một số cột, hệ thống sẽ bỏ qua dòng đó

#### 2.5. Export ra Excel

**Các bước:**
1. Click nút **"Export Excel"** (màu vàng)
2. Hộp thoại **"Lưu file Excel"** hiện ra
3. Chọn thư mục và đặt tên file (mặc định: `Danh_sach_sinh_vien_YYYYMMDD.xlsx`)
4. Click **"Lưu"**
5. Thông báo: **"Export thành công!"**

**File Excel export bao gồm:**
- Header có màu nền xanh nhạt
- Tất cả sinh viên hiện tại (hoặc danh sách đã lọc)
- Các cột: Mã SV, Họ tên, Ngày sinh, Giới tính, Email, Mã Lớp
- Tự động điều chỉnh độ rộng cột

#### 2.6. Bộ lọc nâng cao (Advanced Filter)

**Mục đích**: Tìm kiếm sinh viên theo nhiều tiêu chí.

**Các bộ lọc có sẵn:**

1. **Tên SV**:
   - Nhập một phần tên (không phân biệt hoa thường)
   - Ví dụ: Nhập "Nguyễn" sẽ tìm tất cả SV có tên chứa "Nguyễn"

2. **Lớp**:
   - Dropdown: "Tất cả" hoặc chọn lớp cụ thể
   - Ví dụ: Chọn "CNTT1" chỉ hiển thị SV lớp CNTT1

3. **Giới tính**:
   - Dropdown: "Tất cả", "Nam", "Nữ"

4. **GPA < (điểm)**:
   - Nhập số điểm (ví dụ: 5.0)
   - Hiển thị SV có GPA thấp hơn điểm này
   - Ví dụ: Nhập "5.0" sẽ tìm SV có GPA < 5.0

**Cách sử dụng:**
1. Điền các tiêu chí lọc vào các ô tương ứng
2. Click nút **"Lọc"** (màu xanh dương)
3. Bảng sẽ chỉ hiển thị sinh viên thỏa mãn **TẤT CẢ** các điều kiện
4. Xem kết quả ở nhãn **"Kết quả: X sinh viên"**

**Ví dụ:**
- Tìm SV tên "Nam" + Lớp "CNTT1" + GPA < 5.0:
  - Tên SV: `Nam`
  - Lớp: `CNTT1`
  - GPA <: `5.0`
  - Click "Lọc"

**Xóa bộ lọc:**
- Click nút **"Xóa lọc"** (màu xám)
- Tất cả bộ lọc sẽ được reset về "Tất cả"
- Bảng hiển thị lại toàn bộ sinh viên

---

### 📊 3. Quản lý Điểm

**Mục đích**: Nhập, sửa, xóa điểm số và theo dõi cảnh báo học vụ.

#### 3.1. Thêm điểm mới

**Các bước:**
1. Click nút **"Thêm điểm"** (màu xanh lá)
2. Form **"Thêm điểm mới"** hiện ra
3. Chọn:
   - **Sinh viên**: Dropdown danh sách SV (định dạng: "Mã SV - Họ tên")
   - **Môn học**: Dropdown danh sách môn (định dạng: "Mã Môn - Tên Môn")
4. Nhập điểm:
   - **Điểm thành phần**: 0.00 - 10.00 (có thể nhập số thập phân)
   - **Điểm thi**: 0.00 - 10.00
5. **Điểm tổng kết** tự động tính: `Điểm TP × 0.3 + Điểm Thi × 0.7`
   - Màu xanh: Điểm ≥ 5.0 (đạt)
   - Màu đỏ: Điểm < 5.0 (không đạt)
6. Click **"Lưu"** để lưu điểm

**Lưu ý:**
- Cặp (Mã SV, Mã Môn) phải là duy nhất
- Nếu đã có điểm cho SV và Môn này, hệ thống sẽ báo lỗi
- Điểm tổng kết được làm tròn 2 chữ số thập phân

#### 3.2. Sửa điểm

**Các bước:**
1. Chọn bản ghi điểm trong bảng (click vào dòng)
2. Click nút **"Sửa"** (màu xanh dương)
3. Form hiện ra với dữ liệu đã điền sẵn
4. Chỉnh sửa điểm (Sinh viên và Môn học bị khóa)
5. Click **"Lưu"**
6. Hệ thống tự động:
   - Tính lại điểm tổng kết
   - Ghi vào Audit Log: Ai sửa, khi nào, giá trị cũ → mới

**Lưu ý:**
- Mọi thay đổi điểm đều được ghi log
- Có thể xem lịch sử thay đổi trong Audit Log (tính năng tương lai)

#### 3.3. Xóa điểm

**Các bước:**
1. Chọn bản ghi điểm trong bảng
2. Click nút **"Xóa"** (màu đỏ)
3. Xác nhận xóa
4. Điểm sẽ bị xóa khỏi hệ thống

#### 3.4. Export bảng điểm

**Các bước:**
1. Click nút **"Export Excel"** (màu vàng)
2. Chọn nơi lưu file
3. File Excel sẽ chứa:
   - Header màu xanh lá
   - Các cột: Mã SV, Họ tên, Mã Môn, Tên Môn, Điểm TP, Điểm Thi, Điểm TK, Xếp loại
   - Tất cả điểm số (hoặc danh sách đã lọc)

**Mục đích**: In bảng điểm, gửi cho phụ huynh, lưu trữ, ...

#### 3.5. Bộ lọc điểm

**Các bộ lọc:**

1. **Sinh viên**: Chọn SV cụ thể hoặc "Tất cả"
2. **Môn học**: Chọn môn cụ thể hoặc "Tất cả"
3. **Điểm từ**: Điểm tổng kết tối thiểu (ví dụ: 5.0)
4. **Điểm đến**: Điểm tổng kết tối đa (ví dụ: 10.0)
5. **Chỉ hiển thị không đạt**: Checkbox - chỉ hiển thị điểm < 5.0

**Ví dụ sử dụng:**
- Tìm tất cả điểm từ 7.0 đến 10.0:
  - Điểm từ: `7.0`
  - Điểm đến: `10.0`
  - Click "Lọc"

- Tìm tất cả điểm không đạt của SV "SV001":
  - Sinh viên: `SV001 - ...`
  - Checkbox "Chỉ hiển thị không đạt": ✓
  - Click "Lọc"

#### 3.6. Cảnh báo học vụ

**Vị trí**: Phần dưới cùng của màn hình Quản lý Điểm

**Hiển thị:**
- Danh sách sinh viên cần cảnh báo với 2 loại:
  1. **GPA thấp**: SV có GPA < 5.0
  2. **Chuyên cần thấp**: SV có tỉ lệ chuyên cần < 80%

**Cột hiển thị:**
- Mã SV
- Họ tên
- Lớp
- GPA
- Loại cảnh báo

**Màu sắc:**
- Tất cả dòng cảnh báo có nền màu đỏ nhạt để dễ nhận biết

**Cách sử dụng:**
- Xem danh sách để biết SV nào cần hỗ trợ
- Click vào dòng để xem chi tiết (tính năng tương lai)
- Danh sách tự động cập nhật khi có thay đổi điểm hoặc chuyên cần

---

## Các tính năng nâng cao

### 1. Audit Log (Lịch sử thay đổi)

**Mục đích**: Ghi lại mọi thay đổi trong hệ thống để truy vết.

**Thông tin được ghi:**
- **Action**: Create, Update, Delete
- **EntityType**: Student, Score, ...
- **EntityID**: Mã của đối tượng bị thay đổi
- **UserName**: Tên người dùng Windows
- **Timestamp**: Thời gian thay đổi
- **Description**: Mô tả chi tiết

**Ví dụ log:**
```
[2024-01-15 14:30:25] Update Score SV001-CS101 by longdh
Description: Cập nhật điểm: TP: 7.5, Thi: 8.0, TK: 7.85 -> TP: 8.0, Thi: 8.5, TK: 8.15
```

**Lưu ý:**
- Audit Log hiện lưu trong bộ nhớ
- Để xem log, cần thêm tính năng xem log (tương lai)
- Log được tự động ghi khi:
  - Thêm/sửa/xóa sinh viên
  - Thêm/sửa/xóa điểm

### 2. Tính GPA tự động

**Công thức:**
```
GPA = Tổng (Điểm TK × Số tín chỉ) / Tổng số tín chỉ
```

**Ví dụ:**
- SV có 3 môn:
  - CS101 (3 tín chỉ): Điểm TK = 8.0
  - CS102 (3 tín chỉ): Điểm TK = 7.5
  - MATH101 (3 tín chỉ): Điểm TK = 6.0
- GPA = (8.0×3 + 7.5×3 + 6.0×3) / 9 = 7.17

**Sử dụng:**
- GPA được tính tự động khi xem Dashboard
- Có thể dùng trong bộ lọc để tìm SV có GPA thấp

### 3. Xếp loại điểm

**Bảng xếp loại:**
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

**Hiển thị:**
- Cột "Xếp loại" trong bảng điểm
- Tự động tính khi nhập điểm

---

## Xử lý lỗi thường gặp

### ❌ Lỗi 1: "Lỗi đọc file Excel"

**Nguyên nhân:**
- File Excel không đúng định dạng
- Thiếu cột hoặc sai thứ tự cột
- Dữ liệu không hợp lệ (ngày sai format, ...)

**Cách khắc phục:**
1. Kiểm tra file Excel có đúng 6 cột: Mã SV, Họ tên, Ngày sinh, Giới tính, Email, Mã Lớp
2. Đảm bảo dòng 1 là header
3. Kiểm tra định dạng ngày: dd/MM/yyyy
4. Đảm bảo Mã Lớp tồn tại trong hệ thống

### ❌ Lỗi 2: "Mã sinh viên đã tồn tại"

**Nguyên nhân:**
- Đang thêm SV mới với Mã SV đã có trong hệ thống

**Cách khắc phục:**
1. Kiểm tra lại Mã SV
2. Sử dụng Mã SV khác
3. Hoặc sửa thông tin SV đã có thay vì thêm mới

### ❌ Lỗi 3: "Điểm của sinh viên này cho môn học này đã tồn tại"

**Nguyên nhân:**
- Đang thêm điểm cho cặp (SV, Môn) đã có điểm

**Cách khắc phục:**
1. Sửa điểm đã có thay vì thêm mới
2. Hoặc xóa điểm cũ rồi thêm mới

### ❌ Lỗi 4: "Vui lòng chọn sinh viên cần sửa/xóa"

**Nguyên nhân:**
- Chưa chọn dòng nào trong bảng trước khi click Sửa/Xóa

**Cách khắc phục:**
1. Click vào một dòng trong bảng để chọn
2. Dòng được chọn sẽ có màu highlight
3. Sau đó click Sửa/Xóa

### ❌ Lỗi 5: Build failed - "IconButton could not be found"

**Nguyên nhân:**
- Thiếu package FontAwesome.Sharp

**Cách khắc phục:**
```bash
dotnet restore
dotnet build
```

### ❌ Lỗi 6: "Lỗi export: ..."

**Nguyên nhân:**
- File đang được mở trong Excel
- Không có quyền ghi vào thư mục

**Cách khắc phục:**
1. Đóng file Excel nếu đang mở
2. Chọn thư mục khác có quyền ghi
3. Kiểm tra dung lượng ổ cứng

---

## FAQ (Câu hỏi thường gặp)

### ❓ Q1: Dữ liệu có được lưu vĩnh viễn không?

**A:** Hiện tại, dữ liệu lưu trong bộ nhớ (in-memory). Khi đóng ứng dụng, dữ liệu sẽ mất. Để lưu vĩnh viễn:
- Export ra Excel trước khi đóng
- Hoặc kết nối database (SQL Server, SQLite) - cần phát triển thêm

### ❓ Q2: Có thể import điểm từ Excel không?

**A:** Hiện tại chỉ hỗ trợ import sinh viên. Import điểm sẽ được thêm trong phiên bản tương lai.

### ❓ Q3: Làm sao để backup dữ liệu?

**A:** 
1. Export danh sách sinh viên ra Excel
2. Export bảng điểm ra Excel
3. Lưu 2 file Excel này ở nơi an toàn

### ❓ Q4: Có thể in báo cáo không?

**A:** Hiện tại chưa có tính năng in trực tiếp. Bạn có thể:
1. Export ra Excel
2. Mở file Excel
3. In từ Excel (File → Print)

### ❓ Q5: Làm sao để thêm lớp mới?

**A:** Hiện tại lớp được khởi tạo trong code. Để thêm lớp mới:
1. Mở file `DataAccess/DataRepository.cs`
2. Thêm vào method `InitializeSampleData()`:
```csharp
Classrooms.Add(new Classroom("KT2", "Kế toán 2", "Khoa Kinh tế"));
```

### ❓ Q6: Có thể đổi màu giao diện không?

**A:** Màu sắc được định nghĩa trong các file Designer. Để đổi màu:
1. Mở file Designer tương ứng
2. Tìm các dòng `Color.FromArgb(...)`
3. Thay đổi giá trị màu

### ❓ Q7: Tại sao không thấy biểu đồ trong Dashboard?

**A:** Biểu đồ (LiveCharts) chưa được triển khai trong phiên bản này. Chỉ hiển thị số liệu dạng text và bảng.

### ❓ Q8: Có thể xem lịch sử thay đổi (Audit Log) không?

**A:** Audit Log đang được ghi nhưng chưa có giao diện xem. Để xem log:
1. Mở file `DataAccess/DataRepository.cs`
2. Xem property `AuditLogs`

---

## Mẹo và thủ thuật

### 💡 Mẹo 1: Tìm kiếm nhanh
- Sử dụng bộ lọc "Tên SV" với một phần tên để tìm nhanh
- Ví dụ: Nhập "Nguyễn" để tìm tất cả SV họ Nguyễn

### 💡 Mẹo 2: Kiểm tra cảnh báo định kỳ
- Mở Dashboard hoặc Quản lý Điểm để xem danh sách cảnh báo
- Nên kiểm tra hàng tuần để kịp thời hỗ trợ SV

### 💡 Mẹo 3: Export định kỳ
- Nên export dữ liệu hàng tuần hoặc hàng tháng để backup
- Đặt tên file có ngày: `Danh_sach_SV_20240115.xlsx`

### 💡 Mẹo 4: Sử dụng Import Excel cho dữ liệu lớn
- Thay vì nhập từng SV, chuẩn bị file Excel và import hàng loạt
- Tiết kiệm thời gian đáng kể

### 💡 Mẹo 5: Lọc điểm không đạt
- Sử dụng checkbox "Chỉ hiển thị không đạt" để nhanh chóng xem SV cần hỗ trợ

---

## Liên hệ và hỗ trợ

Nếu gặp vấn đề hoặc có câu hỏi:
1. Kiểm tra phần "Xử lý lỗi thường gặp" ở trên
2. Xem file README.md để biết thêm thông tin kỹ thuật
3. Kiểm tra file SampleData/StudentTemplate.md để xem mẫu Excel

---

## Changelog

### Version 1.0.0 (Hiện tại)
- ✅ Quản lý sinh viên (CRUD)
- ✅ Quản lý điểm số
- ✅ Dashboard thống kê
- ✅ Import/Export Excel
- ✅ Bộ lọc nâng cao
- ✅ Cảnh báo học vụ
- ✅ Audit Log

### Tính năng tương lai (Roadmap)
- [ ] Kết nối database thực
- [ ] Biểu đồ trực quan (LiveCharts)
- [ ] Quản lý chuyên cần chi tiết
- [ ] In báo cáo trực tiếp
- [ ] Đăng nhập/Phân quyền
- [ ] Gửi email cảnh báo
- [ ] Xem Audit Log trong giao diện

---

**Tài liệu này được cập nhật lần cuối: 2024-01-15**

