// let btnAdd = document.getElementById('btnAdd');
// console.log(btnAdd);

//
function test(){
    for(let index = 0; index < 10; index++){
        let a = 1;
        console.log(a);
        a++;
    }
    a = 200;
    console.log(a);
    //điểm khác biệt là khi để a = 200 thì nó kiểu global variable, 
    //k bị giới hạn trong function, còn với let, var, const thì giới hạn trong function, chỉ function đó mới dùng được
    //khai báo var thì khai báo ở đâu nó cũng đẩy lên đầu tiên, kiểu a = 2; var a = 1 => var a = 1; a=2
}

//cách đặt tên function : coding convention



function getName(name){
    try{
        const a=1;
        console.log(b); //khi code k báo lỗi, nhưng runtime, chạy thì mới báo lỗi, nhưng muốn getName chết mà getName2 chạy bình thường thì dùng try catch
        return name;
    }catch(error){
        console.log(error);
    }
}
function getName2(){
    const a=1;
    console.log(a);
}

window.onload = function(){
    //gán sự kiện cho các thành phần:
    initEvents();
    //load dữ liệu cho table
}
//cách comment : 1/ 2 **: "/** */"
/**
 * Tạo các sự kiện cho các button...
 * Author: LDTUAN (18/04/2023)
 * 
 */
function initEvents(){
    try {
        // Add:
        const btnAdd = document.querySelector('#btnAdd');
        btnAdd.addEventListener("click", btnClick);
        btnAdd.ondblclick = function(){
            // hiển thị form chi tiết nhân viên
            document.querySelector('.popup').style.visibility = 'visible';
            // lấy tên nhân viên gán vào text box họ về tên
            const name = "tuan";
            const txt = document.querySelector('#hvt');
            txt.placeholder.value = name;
            //focus vào ô nhập liệu đầu tiên
            txt.focus;
        }
        // ...
    } catch (error) {
        
    }
}

/**
 * bắt sự biện btn click
 */
function btnClick(){

}
/**
 * 
 */
function btnSaveOnClick(){
    try {
        // Thực hiện validate dữ liệu
        const errors = validateData();
        // Nếu dữ liệu hợp lệ thì gọi api thực hiện cất dữ liệu
        
        // Nếu không hợp lệ thì hiển thị thông báo lỗi cụ thể
        if(errors.length > 0){
            // Hiển thị chi tiết thông tin lỗi
            showErrors(errors);
        }else{

        }
    } catch (error) {
        
    }
}
/**
 * 
 */
function validateData(){
    var errors = [];
    // thêm chữ required vào các ô input cần phải nhập
    // Kiểm tra các dữ liệu bắt buộc nhập và không để trống
    let inputRequired = document.querySelectorAll('[required]');
    for(const input of inputRequired){
        const value = input.value;
        if(value == ""){

            // lấy ra thông tin của field-lable
            const label = input.getAttribute('field-label');
            console.log(`${label} khog duoc de trong`);
            errors.push(`${label} khog duoc de trong`);
        }
        console.log(value);
    }
    // Kiểm tra các dữ liệu cần đúng định dạng

    // Kiểm tra các dữ liệu ngày tháng (ngày sinh không lớn hơn hiện tại)

    // Kiểm tra độ dài của các chuỗi có giới hạn số lượng ký tự (VD nghiệp vụ yêu cầu mã nhân viên không được lớn hơn 20 ký tự)
    i
    
    return errors;
}
/**
 * 
 */
function showErrors(){
    
}