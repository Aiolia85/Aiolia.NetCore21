<template>
    <div class="jexcel_container">
        <table class="jexcel" cellpadding="0" cellspacing="0" unselectable="yes" style="width:600px;">
            <thead>
                <tr>
                    <td v-for="h in Header" :key="h">{{h}}</td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(row,idx) in CalData" :key="row.cordY">
                    <td class="jexcel_row">{{idx+1}}</td>
                    <td v-for="col in row" :key="col.cordX" v-bind:class="{'highlight-selected':col.selected, 'highlight':col.selected, 'highlight-top':col.selected, 'highlight-bottom':col.selected, 'highlight-left':col.selected, 'highlight-right':col.selected }" v-on:click="selectCell(col)">{{col.ValDisp}}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    var getColumnName = function (i) {
        var letter = '';
        if (i > 701) {
            letter += String.fromCharCode(64 + parseInt(i / 676));
            letter += String.fromCharCode(64 + parseInt((i % 676) / 26));
        } else if (i > 25) {
            letter += String.fromCharCode(64 + parseInt(i / 26));
        }
        letter += String.fromCharCode(65 + (i % 26));

        return letter;
    }

    export default {
        props: {

        },
        data: function () {
            return {
                CalData: [],
                Header: [],
                //cells: [{ cordX: 1, cordY: 1, ValDisp: "1" }, { cordX: 2, cordY: 2, ValDisp: "2" }, { cordX: 3, cordY: 3, ValDisp: "3" }, { cordX: 5, cordY: 5, ValDisp: "5" }]
            }
        },
        beforeCreate: function () {
           
        },
        mounted: function () {
            this.transferData();
        },
        beforeDestory: function () {

        },
        methods: {
            selectCell: function (col) {
                console.log(col);
                col.selected = true;
            },
            transferData: function () {
                let cells = [{ cordX: 1, cordY: 1, ValDisp: "1", JClass: "" }, { cordX: 2, cordY: 2, ValDisp: "2", JClass: "" }, { cordX: 3, cordY: 3, ValDisp: "3", JClass: "" }, { cordX: 5, cordY: 5, ValDisp: "5", JClass: "" }];

                let _this = this;
                console.log(cells);
                _this.Caldata = [];

                let maxX = 0;
                let maxY = 0;

                //for (let cell in cells) {
                for (let i = 0; i < cells.length; i++) {
                    let cell = cells[i];
                    console.log(cell.cordX);
                    console.log(cell.cordY);
                    if (cell.cordX > maxX)
                        maxX = cell.cordX;

                    if (cell.cordY > maxY)
                        maxY = cell.cordY;
                }

                for (let i = 0; i < maxY+1; i++) {
                    let tmp = [];
                    for (let j = 0; j < maxX+1; j++) {
                        tmp.push(null);
                    }
                    
                    _this.CalData.push(tmp);
                }
                console.log(maxX);
                console.log(maxY);
                console.log(_this.CalData);
                for (let i = 0; i < cells.length; i++) {
                    let cell = cells[i];
                    _this.CalData[cell.cordX-1][cell.cordY-1] = cell;
                }

                this.Header = [];
                this.Header.push("");
                for (let i = 0; i < maxX+1; i++) {
                    this.Header.push(getColumnName(i));
                }

                for (let i = 0; i < _this.CalData.length; i++) {
                    for (let j = 0; j < _this.CalData[i].length; j++) {
                        if (!_this.CalData[i][j]) {
                            _this.CalData[i][j] = { cordX:j+1, cordY:i+1 };
                        }
                    }
                }

                //this.$set('Caldata', _this.CalData);
                //this.$set('Header', _header);
                //this.CalData.$set()
            }
        }

    }
</script>
