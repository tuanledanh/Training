<template>
    <div class="container__popup">
        <div class="popup__button">
            <label class="popup__label" for="">Tiêu đề phân hệ</label>
            <div class="popup--right">
                <button @click="btnAddOnClick" class="button button--icon button__view" id="btnViewPopup">
                    <div class="button__icon">
                        <div class="icon-add">
                            <i class="fas fa-plus"></i>
                        </div>
                    </div>
                    <div class="button__text">
                        Thêm mới
                    </div>
                </button>
                <div class="icon-option">
                    <i class="fas fa-ellipsis-h"></i>
                </div>
            </div>
        </div>
        <!-- <EmployeeForm v-if="showDetailForm" :employeeItem="employeeSelected" @onClose="onCLoseDetail"></EmployeeForm> -->
        <router-view name="EmployeeRouterView"></router-view>
    </div>
    <div class="container__content content">
        <EmployeeList></EmployeeList>
        <div class="content__page page">
            <div class="page__total-record">
                <label for="" class="total-record__text">Total: 15 records</label>
            </div>
            <div class="page__option">
                <div class="option__record-per-page">
                    <label class="record-per-page__label--left" for="">Record/page</label>
                    <select class="record-per-page__select" name="" id="">
                        <option value="15">15</option>
                        <option value="20">20</option>
                        <option value="30">30</option>
                    </select>
                    <label class="record-per-page__label--right" for="">1 - 15 records</label>
                </div>
                <div class="option__paging">
                    <div class="paging__icon">
                        <div class="icon--prev">
                            <div class="icon--prev-page"></div>
                        </div>
                        <div class="icon--next">
                            <div class="icon--next-page"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import EmployeeList from './EmployeeList.vue'
export default {
    name: 'EmployeeHome',
    components: { EmployeeList },
    created() {
        this.$memitter.on("onSelectedEmployeeEmitter", this.onSelectedEmployee);
    },
    beforeUnmount(){
        this.$memitter.off("onSelectedEmployeeEmitter");
    },
    methods: {
        /**
         * Điều hướng người dùng đến url được chỉ định, ở đây là /employee/create
         * Author: LDTUAN (03/05/2023)
         */
        btnAddOnClick() {
            this.$router.push("/employee/create");
        },
        /**
         * Hiển thị thông tin người dùng qua popup khi double click vào bản ghi ở list employees
         * @param {Employee} employee thông tin của employee 
         * Author: LDTUAN (03/05/2023)
         */
        onSelectedEmployee(employee) {
            //Hiển thị form chi tiết:
            this.showDetailForm = true;
            //Truyền data cho form chi tiết:
            this.employeeSelected = employee;
        },
    },
    data() {
        return {
            showDetailForm: false,
            employeeSelected: {},
        }
    },
}
</script>