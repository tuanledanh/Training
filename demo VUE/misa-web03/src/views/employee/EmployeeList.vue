<template>
  <div class="content-header">
    <div class="content-header__input">
      <div class="nav__input input" style="width: 280px">
        <div class="input__icon icon--search"></div>
        <input
          class="input__holder"
          type="text"
          placeholder="Tìm kiếm trong danh sách"
        />
      </div>
    </div>
    <div class="content-header__option" @click="reloadData">
      <div class="icon--reload"></div>
    </div>
  </div>
  <div class="content__table table">
    <div class="table__head head">
      <div class="head__checkbox">
        <input type="checkbox" name="myCheckbox" value="1" v-model="selectedAll" @click="headOnClick"/>
      </div>
      <div class="head__text">EmployeeCode</div>
    </div>
    <div class="table__head head">
      <div class="head__text">DepartmentName</div>
      <div class="head__icon">
        <div class="icon head__icon--sort">
          <div class="icon--sort"></div>
        </div>
        <div class="icon head__icon--filter">
          <div class="icon--filter"></div>
        </div>
      </div>
    </div>
    <div class="table__head head">
      <div class="head__text">FullName</div>
    </div>
    <div class="table__head head">
      <div class="head__text">GenderName</div>
    </div>
    <div
      v-for="(item, index) in employees"
      :key="index"
      @dblclick="rowOnDbClick(item)"
      @click="rowOnClick($event.currentTarget)"
      class="table__body"
    >
      <div class="table__data data">
        <div class="data__checkbox">
          <input
            type="checkbox"
            name="myCheckbox"
            value="1"
            @click.stop="checkboxOnClick($event.currentTarget)"
          />
        </div>
        <div class="data__text">{{ item.EmployeeCode }}</div>
      </div>
      <div class="table__data data">
        <div class="data__text">{{ item.DepartmentName }}</div>
      </div>
      <div class="table__data data">
        <div class="data__text">{{ item.FullName }}</div>
      </div>
      <div class="table__data data">
        <div class="data__text">{{ item.GenderName }}</div>
      </div>
    </div>
  </div>
  <MISALoading v-if="isLoading"></MISALoading>
</template>
<script>
import router from "@/router";
export default {
  name: "EmployeeList",
  emits: ["onSelectedEmployee"],
  created() {
    // lấy dữ liệu
    this.loadData();
  },
  methods: {
    /**
     * Tải lại data khi người dùng click button reload
     * Author: LDTUAN (03/05/2023)
     */
    reloadData() {
      this.loadData();
    },

    /**
     * Phương thức thực hiện tải data từ api
     * Author: LDTUAN (03/05/2023)
     */
    loadData() {
      // lấy dữ liệu
      this.isLoading = true;
      this.$tuanLDAxios
        .get("https://cukcuk.manhnv.net/api/v1/Employees")
        .then((res) => {
          console.log(res.data);
          this.employees = res.data;
          this.isLoading = false;
        })
        .catch((res) => {
          //catch if have error
          console.log(res);
        });
    },
    /**
     * Khi người dùng click vào các row chưa được chọn thì sẽ chuyển sang trạng thái đã chọn và ngược lại
     * @param {*} row là hàng mà người dùng click trong bảng dữ liệu
     * Author: LDTUAN (04/05/2023)
     */
    rowOnClick(row) {
      // Nếu row đã được chọn, bỏ chọn và xóa khỏi danh sách
      if (this.isSelected(row)) {
        this.unselectRow(row);
      }
      // Nếu row chưa được chọn, chọn và thêm vào danh sách
      else {
        this.selectRow(row);
      }
    },
    /**
     * Kiểm tra xem hàng mà người dùng click đã được chọn chưa
     * @param {*} row là hàng mà người dùng click trong bảng dữ liệu
     * Author: LDTUAN (04/05/2023)
     */
    isSelected(row) {
      return this.selectedRows.includes(row);
    },
    /**
     * Push hàng được chọn vào trong 1 mảng và đổi màu background
     * @param {*} row là hàng mà người dùng click trong bảng dữ liệu
     * Author: LDTUAN (04/05/2023)
     */
    selectRow(row) {
      this.selectedRows.push(row);
      this.updateRowStyle(row);
    },
    /**
     * Bỏ hàng dữ liệu đã được chọn trước đó ra khỏi mảng và đổi lại màu background như cũ
     * @param {*} row là hàng mà người dùng click trong bảng dữ liệu
     * Author: LDTUAN (04/05/2023)
     */
    unselectRow(row) {
      const index = this.selectedRows.indexOf(row);
      if (index > -1) {
        this.selectedRows.splice(index, 1);
        this.updateRowStyle(row);
      }
    },
    /**
     * Đổi màu background của hàng khi được chọn hoặc bỏ chọn
     * @param {*} row là hàng mà người dùng click trong bảng dữ liệu
     * Author: LDTUAN (04/05/2023)
     */
    updateRowStyle(row) {
      const checkbox = row.querySelector("input[type=checkbox]");
      const isChecked = this.isSelected(row);
      checkbox.checked = isChecked;
      row.style.backgroundColor = isChecked ? "rgba(80,184,60,0.1)" : "";
    },
    /**
     * Phòng trường hợp double click khi người dùng click checkbox thì nó tính cả rowOnClick, khiến ô checkbox không thể checked
     * @param {*} event
     * Author: LDTUAN(04/05/2023)
     */
    checkboxOnClick(event) {
      const row = event.closest(".table__body");
      this.rowOnClick(row);
    },
    /**
     * Khi người dùng double click vào 1 row trên table, người dùng sẽ được điều hướng
     * tới đường dẫn mới với id của nhân viên được truyền vào
     * Rồi dùng emit để gửi 1 event tới component onSelectedEmployeeEmitter để thực hiện
     * mở popup có chứa thông tin của employee này
     * @param {Employee} employee thông tin của nhân viên
     * Author: LDTUAN (03/05/2023)
     */
    rowOnDbClick(employee) {
      router.push(`/employee/${employee.EmployeeId}`);
      //this.$emit("onSelectedEmployee", employee);
      this.$memitter.emit("onSelectedEmployeeEmitter", employee);
    },

    headOnClick(){
        if(this.selectedAll){
            this.selectedAll = false;
        }else{
            this.selectedAll = true;
        }
        console.log(this.selectedAll);
    }
  },
  data() {
    return {
      employees: [],
      isLoading: false,
      selectedRows: [],
      selectedAll: false,
    };
  },
};
</script>
