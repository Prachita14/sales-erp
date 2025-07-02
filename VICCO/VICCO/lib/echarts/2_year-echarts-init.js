MaterialGroupChange();
MaterialChange();

function MaterialChange() {

    var material_group = $(".Group").val();

    var obj = { "group": material_group };

    $(function () {
        $.ajax({
            type: "POST",
            url: "../Home.aspx/GetProductValueLinechart",
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // ============================================================== 
                // Bar chart option
                // ============================================================== 
                var myChart = echarts.init(document.getElementById('bar-chart'));

                // specify chart configuration item and data
                option = {
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: ['2018', '2019']
                    },
                    toolbox: {
                        show: true,
                        feature: {

                            magicType: { show: true, type: ['line', 'bar'] },
                            restore: { show: true },
                            saveAsImage: { show: true }
                        }
                    },
                    color: ["#76b11f", "#de7c45"],
                    calculable: true,
                    xAxis: [
        {
            type: 'category',
            data: ['Apr', 'May', 'Jun', 'July', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec', 'Jan', 'Feb', 'Mar']
        }
    ],
                    yAxis: [
        {
            type: 'value'
        }
    ],
                    series: [
        {
            name: '2018',
            type: 'bar',
            data: response.d[1],
            markPoint: {
                data: [
                    { type: 'max', name: 'Max' },
                    { type: 'min', name: 'Min' }
                ]
            },
            markLine: {
                data: [
                    { type: 'average', name: 'Average' }
                ]
            }
        },

       {
           name: '2019',
           type: 'bar',
           data: response.d[2],
           markPoint: {
               data: [
                    { type: 'max', name: 'Max' },
                    { type: 'min', name: 'Min' }
                ]
           },
           markLine: {
               data: [
                    { type: 'average', name: 'Average' }
                ]
           }
       }

    ]
                };
                // use configuration item and data specified to show chart
                myChart.setOption(option, true), $(function () {
                    function resize() {
                        setTimeout(function () {
                            myChart.resize()
                        }, 100)
                    }
                    $(window).on("resize", resize), $(".sidebartoggler").on("click", resize)
                });
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });
}


// ============================================================== 
// Bar chart option
// ==============================================================

function MaterialGroupChange() {

    var material_group = $(".Group1").val();

    var obj = { "group": material_group };

    $(function () {
        $.ajax({
            type: "POST",
            url: "../Home.aspx/GetProductQtyLinechart",
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                // ============================================================== 
                // Bar chart option
                // ============================================================== 
                var myChart = echarts.init(document.getElementById('bar-chart_id'));

                // specify chart configuration item and data
                option = {
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: ['2018', '2019']
                    },
                    toolbox: {
                        show: true,
                        feature: {

                            magicType: { show: true, type: ['line', 'bar'] },
                            restore: { show: true },
                            saveAsImage: { show: true }
                        }
                    },
                    color: ["#4775ee", "#c33b64"],
                    calculable: true,
                    xAxis: [
        {
            type: 'category',
            data: ['Apr', 'May', 'Jun', 'July', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec', 'Jan', 'Feb', 'Mar']
        }
    ],
                    yAxis: [
        {
            type: 'value'
        }
    ],
                    series: [
        {
            name: '2018',
            type: 'bar',
            data: response.d[1],
            markPoint: {
                data: [
                    { type: 'max', name: 'Max' },
                    { type: 'min', name: 'Min' }
                ]
            },
            markLine: {
                data: [
                    { type: 'average', name: 'Average' }
                ]
            }
        },
        {
            name: '2019',
            type: 'bar',
            data: response.d[2],
            markPoint: {
                data: [
                    { type: 'max', name: 'Max' },
                    { type: 'min', name: 'Min' }
                ]
            },
            markLine: {
                data: [
                    { type: 'average', name: 'Average' }
                ]
            }
        }
    ]
                };
                // use configuration item and data specified to show chart
                myChart.setOption(option, true), $(function () {
                    function resize() {
                        setTimeout(function () {
                            myChart.resize()
                        }, 100)
                    }
                    $(window).on("resize", resize), $(".sidebartoggler").on("click", resize)
                });


            },
            error: function (response) {
                alert(response.d);
            }
        });
    });

}




// ============================================================== 
// Line chart
// ============================================================== 
var dom = document.getElementById("main");
var mytempChart = echarts.init(dom);
var app = {};
option = null;
option = {

    tooltip: {
        trigger: 'axis'
    },
    legend: {
        data: ['max temp', 'min temp']
    },
    toolbox: {
        show: true,
        feature: {
            magicType: { show: true, type: ['line', 'bar'] },
            restore: { show: true },
            saveAsImage: { show: true }
        }
    },
    color: ["#55ce63", "#009efb"],
    calculable: true,
    xAxis: [
        {
            type: 'category',

            boundaryGap: false,
            data: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']
        }
    ],
    yAxis: [
        {
            type: 'value',
            axisLabel: {
                formatter: '{value} °C'
            }
        }
    ],

    series: [
        {
            name: 'max temp',
            type: 'line',
            color: ['#000'],
            data: [11, 11, 15, 13, 12, 13, 10],
            markPoint: {
                data: [
                    { type: 'max', name: 'Max' },
                    { type: 'min', name: 'Min' }
                ]
            },
            itemStyle: {
                normal: {
                    lineStyle: {
                        shadowColor: 'rgba(0,0,0,0.3)',
                        shadowBlur: 10,
                        shadowOffsetX: 8,
                        shadowOffsetY: 8
                    }
                }
            },
            markLine: {
                data: [
                    { type: 'average', name: 'Average' }
                ]
            }
        },
        {
            name: 'min temp',
            type: 'line',
            data: [1, -2, 2, 5, 3, 2, 0],
            markPoint: {
                data: [
                    { name: 'Week minimum', value: -2, xAxis: 1, yAxis: -1.5 }
                ]
            },
            itemStyle: {
                normal: {
                    lineStyle: {
                        shadowColor: 'rgba(0,0,0,0.3)',
                        shadowBlur: 10,
                        shadowOffsetX: 8,
                        shadowOffsetY: 8
                    }
                }
            },
            markLine: {
                data: [
                    { type: 'average', name: 'Average' }
                ]
            }
        }
    ]
};

if (option && typeof option === "object") {
    mytempChart.setOption(option, true), $(function () {
        function resize() {
            setTimeout(function () {
                mytempChart.resize()
            }, 100)
        }
        $(window).on("resize", resize), $(".sidebartoggler").on("click", resize)
    });
}
