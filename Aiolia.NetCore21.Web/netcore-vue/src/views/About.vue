<template>
    <div class="row">
      
        <aiolia-modal title="hahaha">
            boddyyyy
        </aiolia-modal>
        <div class="row">
            <div class="row">
                <aiolia-form-group label="推送项目" id="pushprojectname">
                    <aiolia-form-datepicker v-bind:options="options"></aiolia-form-datepicker>
                </aiolia-form-group>

                <aiolia-form-group label="推送项目" id="testid">
                    <aiolia-form-datepicker></aiolia-form-datepicker>
                </aiolia-form-group>
            </div>
            <div class="row">
                <aiolia-form-group label="推送项目" id="test1">
                </aiolia-form-group>

                <aiolia-form-group label="推送项目" id="test2">
                </aiolia-form-group>
            </div>
        </div>
            <div class="row" style="width:100%">
                <aiolia-excel-table>

                </aiolia-excel-table>
            </div>
    </div>
</template>

<script>// @ is an alias to /src
 import AioliaFormDatepicker from '@/components/aiolia-form-datepicker.vue'
 import AioliaModal from '@/components/aiolia-modal.vue'
import AioliaFormGroup from '@/components/aiolia-form-group.vue'
    import AioliaExcelTable from '@/components/aiolia-excel-table.vue'
export default {
    name: 'about',
    data: function () {
            return {
                abc: [{ cordX: 1, cordY: 1, ValDisp: "1" }, { cordX: 2, cordY: 2, ValDisp: "2" }, { cordX: 3, cordY: 3, ValDisp: "3" }, { cordX: 5, cordY: 5, ValDisp: "5" }],
                options: { closeText: "hahaha", minDate: new Date(2018, 1 - 1, 1)}
            }
    },
    components: {
        AioliaFormDatepicker,
        AioliaModal,
        AioliaFormGroup,
        AioliaExcelTable
    } 
}</script>
