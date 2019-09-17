<template>
    <input class="form-control" />
</template>

<script>
    import $ from 'jquery'
    import '@/assets/lib/jquery-ui/jquery-ui.min.css'
    import '@/assets/lib/jquery-ui/jquery-ui.min.js'

    export default {
        //data: function () {
        //    return {
        //        options: {

        //        }
        //    }
        //},
        props:["options"],
        mounted: function () {
            var _this = this;
            console.log(_this.options);
            $(this.$el).datepicker(_this.options);
        },
        beforeDestory: function () {
            $(this.$el).datepicker("hide").datepicker("destory");
        }

    }
</script>

