# Hướng dẫn sử dụng Hệ thống Quản lý Sinh viên

## 🚀 Khởi động ứng dụng

1. Mở terminal/command prompt tại thư mục dự án
2. Chạy lệnh:
   ```bash
   dotnet run
   ```

Hoặc build và chạy file .exe:
```bash
dotnet build
# File .exe sẽ nằm trong bin/Debug/net8.0-windows/
```

## 📋 Các chức năng chính

### 1. Dashboard (Trang chủ)
- Hiển thị thống kê tổng quan:
  - Tổng số sinh viên
  - Số sinh viên nợ môn (GPA < 5.0)
  - Tỉ lệ chuyên cần trung bình
  - Tỉ lệ giới tính (Nam/Nữ)
- Thống kê theo lớp
- Danh sách cảnh báo học vụ

### 2. Quản lý Sinh viên

#### Thêm sinh viên mới:
1. Click nút **"Thêm mới"**
2. Điền đầy đủ thông tin:
   - Mã SV (bắt buộc, không trùng)
   - Họ tên (bắt buộc)
   - Ngày sinh
   - Giới tính
   - Email
   - Lớp
3. Click **"Lưu"**

#### Sửa thông tin sinh viên:
1. Chọn sinh viên trong bảng
2. Click nút **"Sửa"**
3. Chỉnh sửa thông tin (trừ Mã SV)
4. Click **"Lưu"**

#### Xóa sinh viên:
1. Chọn sinh viên trong bảng
2. Click nút **"Xóa"**
3. Xác nhận xóa

#### Import từ Excel:
1. Click nút **"Import Excel"**
2. Chọn file Excel (định dạng .xlsx hoặc .xls)
3. File Excel cần có cấu trúc:
   - Dòng 1: Header (Mã SV, Họ tên, Ngày sinh, Giới tính, Email, Mã Lớp)
   - Từ dòng 2: Dữ liệu sinh viên
4. Hệ thống sẽ tự động import các sinh viên mới (bỏ qua nếu Mã SV đã tồn tại)

#### Export ra Excel:
1. Click nút **"Export Excel"**
2. Chọn nơi lưu file
3. File Excel sẽ được tạo với danh sách sinh viên hiện tại

#### Bộ lọc nâng cao:
- **Tên SV**: Tìm kiếm theo tên (có thể tìm một phần tên)
- **Lớp**: Lọc theo lớp cụ thể
- **Giới tính**: Lọc theo Nam/Nữ
- **GPA <**: Tìm sinh viên có GPA thấp hơn điểm chỉ định
- Click **"Lọc"** để áp dụng
- Click **"Xóa lọc"** để hiển thị tất cả

### 3. Quản lý Điểm

#### Thêm điểm mới:
1. Click nút **"Thêm điểm"**
2. Chọn Sinh viên và Môn học
3. Nhập:
   - Điểm thành phần (0-10)
   - Điểm thi (0-10)
4. Điểm tổng kết sẽ tự động tính: **Điểm TP × 0.3 + Điểm Thi × 0.7**
5. Click **"Lưu"**

#### Sửa điểm:
1. Chọn bản ghi điểm trong bảng
2. Click nút **"Sửa"**
3. Chỉnh sửa điểm
4. Click **"Lưu"**
5. Hệ thống sẽ ghi lại lịch sử thay đổi (Audit Log)

#### Xóa điểm:
1. Chọn bản ghi điểm
2. Click nút **"Xóa"**
3. Xác nhận xóa

#### Export bảng điểm:
1. Click nút **"Export Excel"**
2. Chọn nơi lưu file
3. File Excel sẽ chứa bảng điểm đầy đủ

#### Bộ lọc điểm:
- **Sinh viên**: Lọc theo sinh viên cụ thể
- **Môn học**: Lọc theo môn học
- **Điểm từ/đến**: Lọc theo khoảng điểm
- **Chỉ hiển thị không đạt**: Chỉ hiển thị điểm < 5.0

#### Cảnh báo học vụ:
- Phần dưới cùng hiển thị danh sách sinh viên cần cảnh báo:
  - **GPA thấp**: Sinh viên có GPA < 5.0
  - **Chuyên cần thấp**: Sinh viên có tỉ lệ chuyên cần < 80%

## 📊 Công thức tính điểm

- **Điểm tổng kết** = Điểm thành phần × 0.3 + Điểm thi × 0.7
- **GPA** = Tổng (Điểm TK × Số tín chỉ) / Tổng số tín chỉ

### Xếp loại:
- **A**: ≥ 8.5
- **B+**: ≥ 8.0
- **B**: ≥ 7.0
- **C+**: ≥ 6.5
- **C**: ≥ 5.5
- **D+**: ≥ 5.0
- **D**: ≥ 4.0
- **F**: < 4.0

## 🔍 Mẹo sử dụng

1. **Tìm kiếm nhanh**: Sử dụng bộ lọc để tìm sinh viên nhanh chóng
2. **Kiểm tra cảnh báo**: Luôn xem phần cảnh báo học vụ để theo dõi sinh viên cần hỗ trợ
3. **Export định kỳ**: Nên export dữ liệu định kỳ để backup
4. **Import hàng loạt**: Sử dụng Import Excel để thêm nhiều sinh viên cùng lúc

## ⚠️ Lưu ý

- Dữ liệu hiện tại được lưu trong bộ nhớ (in-memory), sẽ mất khi đóng ứng dụng
- Để lưu trữ vĩnh viễn, cần kết nối database
- Mã SV và cặp (Mã SV, Mã Môn) phải là duy nhất
- Tất cả các thao tác đều được ghi lại trong Audit Log

## 🐛 Xử lý lỗi

- **Lỗi import Excel**: Kiểm tra định dạng file và cấu trúc dữ liệu
- **Không tìm thấy sinh viên**: Kiểm tra bộ lọc có đang bật không
- **Lỗi tính điểm**: Đảm bảo điểm nhập vào từ 0-10

## 📞 Hỗ trợ

Nếu gặp vấn đề, vui lòng kiểm tra:
1. File README.md để biết thêm thông tin
2. Cấu trúc file Excel mẫu trong SampleData/StudentTemplate.md

