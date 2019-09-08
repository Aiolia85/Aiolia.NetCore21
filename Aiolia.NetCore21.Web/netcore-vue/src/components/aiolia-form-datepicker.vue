<template>
    <input class="form-control" />
</template>

<script>
    import $ from 'jquery'
    import '@/assets/lib/jquery-ui/jquery-ui.min.css'
    import '@/assets/lib/jquery-ui/jquery-ui.min.js'

    export default {
        mounted: function () {
            $(this.$el).datepicker();
        },
        beforeDestory: function () {
            $(this.$el).datepicker("hide").datepicker("destory");
        }

    }
</script>

