# Mẫu file Excel để Import Sinh viên

File Excel cần có cấu trúc như sau:

| Mã SV | Họ tên | Ngày sinh | Giới tính | Email | Mã Lớp |
|-------|--------|-----------|-----------|-------|--------|
| SV004 | Phạm Thị Dung | 15/03/2001 | Nữ | dung.pham@email.com | CNTT1 |
| SV005 | Hoàng Văn Em | 20/07/2000 | Nam | em.hoang@email.com | CNTT2 |
| SV006 | Nguyễn Thị Phương | 10/11/2001 | Nữ | phuong.nguyen@email.com | KT1 |

**Lưu ý:**
- Dòng đầu tiên là header (sẽ bị bỏ qua khi import)
- Ngày sinh định dạng: dd/MM/yyyy hoặc MM/dd/yyyy
- Giới tính: "Nam" hoặc "Nữ"
- Mã Lớp phải tồn tại trong hệ thống

## Cách tạo file Excel mẫu:

1. Mở Excel
2. Tạo sheet mới với tên bất kỳ
3. Nhập header ở dòng 1: Mã SV, Họ tên, Ngày sinh, Giới tính, Email, Mã Lớp
4. Nhập dữ liệu từ dòng 2 trở đi
5. Lưu file với định dạng .xlsx

## Dữ liệu mẫu có sẵn trong hệ thống:

- **Lớp học:**
  - CNTT1 - Công nghệ thông tin 1
  - CNTT2 - Công nghệ thông tin 2
  - KT1 - Kế toán 1

- **Môn học:**
  - CS101 - Lập trình C#
  - CS102 - Cơ sở dữ liệu
  - CS103 - Lập trình Web
  - MATH101 - Toán cao cấp

