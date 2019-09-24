<template>
    <div class="jexcel_container">
        <table class="jexcel" cellpadding="0" cellspacing="0" unselectable="yes" style="width:600px;">
            <thead>
                <tr>
                    <td v-for="h in Header" :key="h.name" v-bind:class="{'selected':h.selected}">{{h.name}}</td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(row,idx) in CalData" :key="row.cordY">
                    <td class="jexcel_row" v-on:click="selectRow(row)">{{idx+1}}</td>
                    <td v-for="col in row" v-on:mousedown="mousedown(col)" v-on:mouseover="mouseover(col)" v-on:mouseup="mouseup" :key="col.cordX" v-bind:class="cell.SysClass" v-on:click="selectCell(col)">{{col.ValDisp}}</td>
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

    var cellClass = function () {
        this.'highlight-selected': col.highlightselected,
            'highlight': col.highlight,
            'highlight-top': col.highlighttop,
            'highlight-bottom': col.highlightbottom,
            'highlight-left': col.highlightleft,
                'highlight-right': col.highlightright
    }
    }


    export default {
        props: [
            "cells"
        ],
        data: function () {
            return {
                CalData: [],
                Header: [],
                highlighted:[]
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
            mousedown: function (cell) {
                console.log(cell);
            },
            selectRow: function (row) {
                this.resetSelection();
                row[0].highlightleft = true;
                for (let i = 0; i < row.length; i++) {
                    this.Header[i+1].selected = true;
                    row[i].highlighttop = true;
                    row[i].highlightbottom = true;
                    this.$set(this.CalData[row[i].cordY - 1], row[i].cordX - 1, row[i]);
                    this.highlighted.push(row[i]);
                }
                
            },
            resetSelection: function () {

                for (let i = 0; i < this.Header.length; i++) {
                    this.Header[i].selected = false;
                }

                for (let i = 0; i < this.highlighted.length; i++) {
                    this.highlighted[i].selected = false;
                    this.highlighted[i].highlightselected = false;
                    this.highlighted[i].highlight = false;
                    this.highlighted[i].highlighttop = false;
                    this.highlighted[i].highlightbottom = false;
                    this.highlighted[i].highlightleft = false;
                    this.highlighted[i].highlightright = false;
                }

                this.highlighted = new Array();
            },
            selectCell: function (col) {

                this.resetSelection();

                col.selected = true;
                col.highlightselected = true;
                col.highlight = true;
                col.highlighttop = true;
                col.highlightbottom = true;
                col.highlightleft = true;
                col.highlightright = true;

                this.Header[col.cordX].selected = true;

                this.$set(this.CalData[col.cordY - 1], col.cordX - 1, col);

                this.highlighted.push(col);
            },
            transferData: function () {

                let _this = this;
                console.log(cells);
                _this.Caldata = [];
                let cells = _this.cells;

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
                this.Header.push({});
                for (let i = 0; i < maxX+1; i++) {
                    this.Header.push({ name: getColumnName(i) });
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
