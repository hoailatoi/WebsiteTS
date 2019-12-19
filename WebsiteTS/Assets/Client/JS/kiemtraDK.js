// JavaScript Document
function KiemTra()
{
	var ten = window.document.frmDangKy.txtHoten.value;
	var re = /^(\w{3,50})$/; 
	if(re.test(ten) == false)
		{
			alert("Độ dài của tên phải từ 3 đến 50 ký tự, viết liền Không dấu và không ký tự đặc biệt");
			return false;
		}
	
	var nam = window.document.frmDangKy.txtNam.value;
	if(isNaN(nam) == true)
		{
			alert("Vui lòng nhập năm là kí tự số!");
			return false;
		}
	
	var email = window.document.frmDangKy.email.value;
	var re4 = /[\w_]+@[a-z0-9]+\.{1}([a-z0-9]{2,9})$/;
	if(re4.test(email) == false)
		{
			alert("Sai định dạng email, Định dạng chuẩn: abc@xyz.xxx");
			return false;
		}
	
	var tendn = window.document.frmDangKy.txtTenDangNhap.value;
	var re2 = /^\w{3,18}$/;
	if(re2.test(tendn) == false)
		{
			alert("Độ dài của tên đăng nhập phải từ 3 tới 18 kí tự và không có kí tự đặc biệt!");
			return false;
		}
	
	var mk = window.document.frmDangKy.txtPass.value;
	var re3= /^[a-zA-Z0-9_@&]{6,18}$/;
	if(re3.test(mk) == false)
		{
			alert("Độ dài của mật khẩu phải từ 6 đến 18 kí tự!");
			return false;
		}
	
	var mknhaplai = window.document.frmDangKy.txtNhapLai.value;
	if(mk != mknhaplai)
		{
			alert("Hai mật khẩu không trùng khớp!");
			return false;
		}
	alert("Đăng ký thành công, Bạn sẽ được đưa về trang chủ !");
}