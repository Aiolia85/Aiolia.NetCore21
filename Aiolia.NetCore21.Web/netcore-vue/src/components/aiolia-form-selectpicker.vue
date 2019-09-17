<template>
    <select></select>
</template>

<script>
    import $ from 'jquery'

    import '@/assets/lib//bootstrap-select/css/bootstrap-select.css'
    import '@/assets/lib/bootstrap-select/js/bootstrap-select.js'

    export default {
        mounted: function () {
            $(this.$el).selectpicker();
        },
        beforeDestory: function () {
            $(this.$el).datepicker("hide").datepicker("destory");
        }

    }
</script>

