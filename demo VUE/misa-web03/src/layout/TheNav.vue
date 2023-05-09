<template>
    <div class="container__nav nav">
      <div class="nav--left">
        <div class="nav__icon-menu icon">
          <div class="icon--menu"></div>
        </div>
        <div class="nav__icon-logo icon">
          <div class="icon--logo"></div>
        </div>
        <div class="nav__label label">KẾ TOÁN</div>
      </div>
      <div class="nav--center">
        <div class="nav__input input">
          <div class="input__icon icon--search"></div>
          <input class="input__holder" type="text" placeholder="Tìm theo mã nhân viên, họ tên, SĐT, Email...">
        </div>
      </div>
      <div class="nav--right">
        <div class="nav__icon">
          <div class="icon--cloud"></div>
        </div>
        <div class="nav__icon">
          <div class="icon--notification"></div>
        </div>
        <div class="nav__icon">
          <div class="icon--question"></div>
        </div>
        <div class="nav__icon">
          <div class="icon--user"></div>
        </div>
      </div>
    </div>
</template>
<script>
export default {
    name:'TheNav'
}
</script>
<style>
</style>