// JavaScript Document

function KiemTra()
{

	var tendn = window.document.frmDangNhap.txtTenDangNhap.value;
	var mk = window.document.frmDangNhap.txtMatKhau.value;
	if(tendn == "Hoai" && mk == "hoai")
			document.frmDangNhap.action = "Trangchu-Admin.html";
	else if(tendn == "Vip" && mk == "123456")
			document.frmDangNhap.action = "Trangchu-KhachVip.html";
	else if(tendn == "khachhang" && mk == "123456")
			document.frmDangNhap.action = "Trangchu-KhachThuong.html";
	else if((tendn != "Hoai" && mk != "hoai")||(tendn != "Vip" && mk != "123456")||(tendn != "khachhang" && mk != "123456"))
			alert("Bạn Đã Nhập Sai Tài Khoản Hoặc Mật Khẩu.Vui Lòng Đăng Nhập Lại!")
	else
			document.frmDangNhap.action = "../../Trangchu.html";
}
