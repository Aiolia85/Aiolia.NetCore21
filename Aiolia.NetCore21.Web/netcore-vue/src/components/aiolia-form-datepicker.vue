<template>
<input />
</template>

<script>
import $ from 'jquery'
import 'jquery-ui/ui/widgets/datapicker'

export default {
        mounted: function () {
        $(this.$el).datapicker();
    }
}
</script>

