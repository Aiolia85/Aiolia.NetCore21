<template>
    <div class="row form-group col">
        <div class="col-4">
            <slot name="label"><label v-bind:for="id">{{label}}<font class="muststar">*</font></label></slot>
        </div>
        <div class="col-8">
            <slot><input v-bind:id="id" v-bind:name="id" class="form-control" /></slot>
        </div>
    </div>
</template>

<script>


    export default {
        props:["label","id"]

}
</script>

