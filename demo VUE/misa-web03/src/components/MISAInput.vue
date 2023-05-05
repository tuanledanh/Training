<template>
    <label for="">biding 1 chiều, thay đổi input thì giá trị của props k đổi</label>
    <input class="m-input" :value="ldtuan" type="text">
    <div>div value: {{ ldtuan }}</div>
    <label for="">/////////////////////////////</label>
    <br>
    <label for="">biding 2 chiều, dùng v-model, thay đổi input thì giá trị cũng thay đổi</label>
    <input class="m-input" v-model="valueLDTuan" type="text">
    <div>div value: {{ valueLDTuan }}</div>
    <br>
    <label for="">///////////////////////////////</label>
    <input class="m-input" v-model="employee.Id" type="text">
    <input class="m-input" v-model="employee.FullName" type="text">
    <input class="m-input" v-model="employee.Gender" type="text">
    <input class="m-input" v-model="employee.Phone" type="text">
    <div>div value: {{ employee }}</div>
    <button @click="btnSaveOnClick">save</button>
    <div>Thông tin nhân viên là: {{ employeeJSON }}</div>
</template>
<script>
export default {
    name:'MISAInput',
    props:['ldtuan'],
    methods:{
        btnSaveOnClick(){
            this.employeeJSON = JSON.stringify(this.employee)
        }
    },
    data() {
        return {
            valueLDTuan:"le danh tuan",
            employee:{},
            employeeJSON:""
        }
    },
};
</script>
<style>
*{
    display: block;
}
</style>