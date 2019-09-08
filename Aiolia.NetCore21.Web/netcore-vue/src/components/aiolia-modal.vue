<template>
    <div class="modal fade" style="margin-top:70px;" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <slot name="header">{{title}}</slot>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <slot></slot>
                </div>
                <div class="modal-footer">
                    <slot name="footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </slot>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

    export default {
        props:["title"],
        mounted: function () {
            $(this.$el).modal();
        },
        beforeDestory: function () {
            //$(this.$el).datepicker("hide").datepicker("destory");
        }

}
</script>

