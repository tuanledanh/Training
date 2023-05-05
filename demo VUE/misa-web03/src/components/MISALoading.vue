<template>
    <div class="loading">
        <div class="loading-wrapper">
            <div class="loading__icon">

            </div>
        </div>
    </div>
</template>
<style>
.loading{
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    position: fixed;
    z-index: 10;
    display: grid;
    place-items: center;
    background-color: rgba(0, 0, 0, 0.188);
}
.loading-wrapper{
    width: 32px;
    height: 32px;
    border-radius: 50%;
    border: 4px solid #2CA01C;
    border-top: 4px solid #FFFFFF;
    animation: spin 1s linear infinite;
}
@keyframes spin {
    0% { transform: rotate(0deg); }
    20% { transform: rotate(180deg); }
    100% { transform: rotate(360deg); }
}
</style>