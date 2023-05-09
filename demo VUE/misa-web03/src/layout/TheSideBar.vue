<template>
    <div class="container__side-bar side-bar">
      <div class="side-bar">
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--overview"></div>
          </div>
          <div class="side-bar__item-name">Tổng quan</div>
        </div>
        <router-link to="/employee" class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--cash"></div>
          </div>
          <div class="side-bar__item-name">Tiền mặt</div>
        </router-link>
        <router-link to="/customer" class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--deposits"></div>
          </div>
          <div class="side-bar__item-name">Tiền gửi</div>
        </router-link>
        <router-link to="/report" class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--purchase"></div>
          </div>
          <div class="side-bar__item-name">Mua hàng</div>
        </router-link>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--sell"></div>
          </div>
          <div class="side-bar__item-name">Bán hàng</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--invoiceManagement"></div>
          </div>
          <div class="side-bar__item-name">Quản lý hóa đơn</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--warehouse"></div>
          </div>
          <div class="side-bar__item-name">Kho</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--tools"></div>
          </div>
          <div class="side-bar__item-name">Công cụ dụng cụ</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--fixedAssets"></div>
          </div>
          <div class="side-bar__item-name">Tài sản cố định</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--tax"></div>
          </div>
          <div class="side-bar__item-name">Thuế</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--price"></div>
          </div>
          <div class="side-bar__item-name">Giá thành</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--synthetic"></div>
          </div>
          <div class="side-bar__item-name">Tổng hợp</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--budget"></div>
          </div>
          <div class="side-bar__item-name">Ngân sách</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--report"></div>
          </div>
          <div class="side-bar__item-name">Báo cáo</div>
        </div>
        <div class="side-bar__item">
          <div class="side-bar__icon">
            <div class="icon--financialAnalysis"></div>
          </div>
          <div class="side-bar__item-name">Phân tích tài chính</div>
        </div>
      </div>
    </div>
</template>
<script>
export default {
    name:'TheSideBar'
}
</script>
<style>
</style>