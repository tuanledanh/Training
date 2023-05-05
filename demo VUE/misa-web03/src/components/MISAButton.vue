<template>
    <div>
        <button class="btn">{{ text }}</button>
    </div>
</template>
<script>
export default {
    name:"MISAButton",
    emits:[],
    props:["text"], // nhận các dữ liệu truyền từ ngoài component
    methods: {
        
    },
    data() {
        return {
            
        }
    },
}
</script>
<style>
.btn{
    height: 36px;
    background-color: aqua;
}
</style>