const numbers = [1, 2, 3, 4, 5, 6, 7];
Chart.defaults.font.size = 10;
// Change default options for ALL charts
Chart.register(ChartDataLabels);

//const numbers = [1];
function gradientcolor(ctx) {
    var background_1 = ctx.createLinearGradient(0, 0, 0, 90);
    background_1.addColorStop(0, '#E8E8E8');
    background_1.addColorStop(1, '#3366FF');

    return background_1;
}

//const machine = [];

//const denoprofile = [];

function getItems() {
    fetch('api/StopReasons/oeeonly')
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error('Unable to get items.', error));
}

$.each(numbers, function (index, value) {
    //console.log(value);
    var chartnum = ('layanan' + value.toString());

    const ctx = document.getElementById(chartnum);
    ctx.classList.add('insidecanvas');
    var background_1 = gradientcolor(ctx.getContext("2d"));
    console.log(ctx);


    if (value == 3 || value == 4) {
        const ctx1 = ctx.getContext("2d");
        ctx1.font = "30px Verdana";
        ctx1.fillStyle = "white";
        ctx1.textAlign = "center";
        ctx1.fillText("Maintenance", ctx.width / 2, ctx.height / 2);
    }
    else if (value == 1 || value == 2) {
        var data = {
            datasets: [{

                data: [],
                backgroundColor: [

                ],
                color: 'white',
                barThickness: 30
            }],
            labels: [

            ],


        };
        var myDoughnutChart = new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {

                responsive: false,
                maintainAspectRatio: false,
                scales: {
                    y: {
                        suggestedMin: 0,
                        suggestedMax: 160,
                        fontColor: "white",
                        ticks: {
                            /*      minRotation: 90,*/
                            color: "#f5f5f5",

                        },
                        border: {
                            display: true
                        },
                        grid: {
                            color: function (context) {
                                if (context.tick.value == 0) {
                                    return '#8A9A5B'
                                }

                                /* return '#000000';*/
                            },
                        }

                    },
                    x: {
                        //type: 'category',

                        //labels: ['January', 'February', 'March', 'April', 'May', 'June'],
                        ticks: {
                            /* minRotation: 90,*/
                            color: "#f5f5f5",
                            align: 'center'
                        },

                    }
                },

                plugins: {
                    title: {
                        display: false,
                        position: 'top',
                        align: 'start',
                        //text: machine[index],
                        text: 'OEE Shift : 58%',
                        color: 'white',
                        padding: {
                            top: 10,
                            bottom: 30
                        },
                    },
                    legend: {
                        labels: {

                            color: 'white',
                        },
                        display: false,
                    },
                    datalabels: {
                        //backgroundColor: function (context) {
                        //    return context.dataset.backgroundColor;
                        //},
                        //borderRadius: 4,
                        anchor: 'end',
                        align: 'top',
                        color: 'white',
                        font: {
                            weight: 'bold'
                        },
                        formatter: Math.round,

                    },
                    layout: {
                        padding: 20
                    }
                }
            }

        });
    }
    else {
        var data = {
            datasets: [{

                data: [40,],
                backgroundColor: [
                    background_1,
                ],
                color: 'white',
                barThickness: 30
            }],
            labels: [
                ['Feeder', 'Stop']
            ],


        };
        var myDoughnutChart = new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {

                responsive: false,
                maintainAspectRatio: false,
                scales: {
                    y: {
                        suggestedMin: 0,
                        suggestedMax: 160,
                        fontColor: "white",
                        ticks: {
                            /*      minRotation: 90,*/
                            color: "#f5f5f5",

                        },
                        border: {
                            display: true
                        },
                        grid: {
                            color: function (context) {
                                if (context.tick.value == 0) {
                                    return '#8A9A5B'
                                }

                                /* return '#000000';*/
                            },
                        }

                    },
                    x: {
                        //type: 'category',

                        //labels: ['January', 'February', 'March', 'April', 'May', 'June'],
                        ticks: {
                            /* minRotation: 90,*/
                            color: "#f5f5f5",
                            align: 'center'
                        },

                    }
                },

                plugins: {
                    title: {
                        display: false,
                        position: 'top',
                        align: 'start',
                        //text: machine[index],
                        text: 'OEE Shift : 58%',
                        color: 'white',
                        padding: {
                            top: 10,
                            bottom: 30
                        },
                    },
                    legend: {
                        labels: {

                            color: 'white',
                        },
                        display: false,
                    },
                    datalabels: {
                        //backgroundColor: function (context) {
                        //    return context.dataset.backgroundColor;
                        //},
                        //borderRadius: 4,
                        anchor: 'end',
                        align: 'top',
                        color: 'white',
                        font: {
                            weight: 'bold'
                        },
                        formatter: Math.round,

                    },
                    layout: {
                        padding: 20
                    }
                }
            }

        });
    }





    
    
   
    

});
////second row chart
$.each(numbers, function (index, value) {
    console.log(value);
    var chartnum = ("barchartB" + value.toString());
    const ctx = document.getElementById(chartnum);
    ctx.classList.add('insidecanvas');
    console.log(ctx);
    var background_1 = gradientcolor(ctx.getContext("2d"));
   
    if (value == 3 || value == 4) {
        const ctx1 = ctx.getContext("2d");
        ctx1.font = "30px Verdana";
        ctx1.fillStyle = "white";
        ctx1.textAlign = "center";
        ctx1.fillText("Maintenance", ctx.width / 2, ctx.height / 2);
    }
    else if (value == 1) {
        var data = {
            datasets: [{

                data: [10],
                backgroundColor: [
                    background_1
                ],
                color: 'white',
                barThickness: 30
            }],
            labels: ['Others'

            ],


        };
        var myDoughnutChart = new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {

                responsive: false,
                maintainAspectRatio: false,
                scales: {
                    y: {
                        suggestedMin: 0,
                        suggestedMax: 160,
                        fontColor: "white",
                        ticks: {
                            /*      minRotation: 90,*/
                            color: "#f5f5f5",

                        },
                        border: {
                            display: true
                        },
                        grid: {
                            color: function (context) {
                                if (context.tick.value == 0) {
                                    return '#8A9A5B'
                                }

                                /* return '#000000';*/
                            },
                        }

                    },
                    x: {
                        //type: 'category',

                        //labels: ['January', 'February', 'March', 'April', 'May', 'June'],
                        ticks: {
                            /* minRotation: 90,*/
                            color: "#f5f5f5",
                            align: 'center'
                        },

                    }
                },

                plugins: {
                    title: {
                        display: true,
                        position: 'top',
                        align: 'centre',
                        //text: machine[index],
                        text: ['5000 Kwacha RS'],
                        color: 'white',
                        padding: {
                            top: 10,
                            bottom: 30
                        },
                    },
                    legend: {
                        labels: {

                            color: 'white',
                        },
                        display: false,
                    },
                    datalabels: {
                        //backgroundColor: function (context) {
                        //    return context.dataset.backgroundColor;
                        //},
                        //borderRadius: 4,
                        anchor: 'end',
                        align: 'top',
                        color: 'white',
                        font: {
                            weight: 'bold'
                        },
                        formatter: Math.round,

                    },
                    layout: {
                        padding: 20
                    }
                }
            }

        });
    }
    else if (value == 2) {
        var data = {
            datasets: [{

                data: [10],
                backgroundColor: [
                    background_1
                ],
                color: 'white',
                barThickness: 30
            }],
            labels: ['Others'

            ],


        };
        var myDoughnutChart = new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {

                responsive: false,
                maintainAspectRatio: false,
                scales: {
                    y: {
                        suggestedMin: 0,
                        suggestedMax: 160,
                        fontColor: "white",
                        ticks: {
                            /*      minRotation: 90,*/
                            color: "#f5f5f5",

                        },
                        border: {
                            display: true
                        },
                        grid: {
                            color: function (context) {
                                if (context.tick.value == 0) {
                                    return '#8A9A5B'
                                }

                                /* return '#000000';*/
                            },
                        }

                    },
                    x: {
                        //type: 'category',

                        //labels: ['January', 'February', 'March', 'April', 'May', 'June'],
                        ticks: {
                            /* minRotation: 90,*/
                            color: "#f5f5f5",
                            align: 'center'
                        },

                    }
                },

                plugins: {
                    title: {
                        display: true,
                        position: 'top',
                        align: 'centre',
                        //text: machine[index],
                        text: ['1000 Kwacha RS'],
                        color: 'white',
                        padding: {
                            top: 10,
                            bottom: 30
                        },
                    },
                    legend: {
                        labels: {

                            color: 'white',
                        },
                        display: false,
                    },
                    datalabels: {
                        //backgroundColor: function (context) {
                        //    return context.dataset.backgroundColor;
                        //},
                        //borderRadius: 4,
                        anchor: 'end',
                        align: 'top',
                        color: 'white',
                        font: {
                            weight: 'bold'
                        },
                        formatter: Math.round,

                    },
                    layout: {
                        padding: 20
                    }
                }
            }

        });
    }
    else {
        var data = {
            datasets: [{

                data: [40,],
                backgroundColor: [
                    background_1,
                ],
                color: 'white',
                barThickness: 30
            }],
            labels: [
                ['Feeder', 'Stop']
            ],


        };
        var myDoughnutChart = new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {

                responsive: false,
                maintainAspectRatio: false,
                scales: {
                    y: {
                        suggestedMin: 0,
                        suggestedMax: 160,
                        fontColor: "white",
                        ticks: {
                            /*      minRotation: 90,*/
                            color: "#f5f5f5",

                        },
                        border: {
                            display: true
                        },
                        grid: {
                            color: function (context) {
                                if (context.tick.value == 0) {
                                    return '#8A9A5B'
                                }

                                /* return '#000000';*/
                            },
                        }

                    },
                    x: {
                        //type: 'category',

                        //labels: ['January', 'February', 'March', 'April', 'May', 'June'],
                        ticks: {
                            /* minRotation: 90,*/
                            color: "#f5f5f5",
                            align: 'center'
                        },

                    }
                },

                plugins: {
                    title: {
                        display: true,
                        position: 'top',
                        align: 'centre',
                        //text: machine[index],
                        text: '1000 Kwacha FS',
                        color: 'white',
                        padding: {
                            top: 10,
                            bottom: 30
                        },
                    },
                    legend: {
                        labels: {

                            color: 'white',
                        },
                        display: false,
                    },
                    datalabels: {
                        //backgroundColor: function (context) {
                        //    return context.dataset.backgroundColor;
                        //},
                        //borderRadius: 4,
                        anchor: 'end',
                        align: 'top',
                        color: 'white',
                        font: {
                            weight: 'bold'
                        },
                        formatter: Math.round,

                    },
                    layout: {
                        padding: 20
                    }
                }
            }

        });
    }

});
////third row chart
$.each(numbers, function (index, value) {
    console.log(value);
    var chartnum = ("barchartC" + value.toString());

    const ctx = document.getElementById(chartnum);
    ctx.classList.add('insidecanvas');
    console.log(ctx);
    var background_1 = gradientcolor(ctx.getContext("2d"));
    var data = {
        datasets: [{
            type: 'line',
            label: 'AVG',
            data: [40.0, 45.0, 50.0, 61.5, 59.3, 48.5, 49.9, 70.2, 72.6, 70.5, 65.5, 60.2, 55.3],
            borderWidth: 2,
            pointStyle: 'circle',
            pointRadius: 3,

            fill: false,
            borderColor: '#03dffc',
            backgroundColor: '#03dffc',
            datalabels: {
                align: 'end',
                anchor: 'end',
                color: '#D6D5CB',
                font: {
                    weight: 'bold'
                },
                
            }
        },
        {
            type: 'bar',
            barThickness: 10,
            label: 'OEE',
            data: [40, 50, 60, 60, 59, 48, 51, 70, 72, 73, 80, 63, 55],
            backgroundColor: [
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
                background_1,
            ],
            datalabels: {
                align: 'center',
                anchor: 'center',
                color: 'white',
                font: {
                    weight: 'bold'
                },
                formatter: Math.round
            }

            /*pointBorderColor: 'rgb(0, 0, 0)'*/
        },],
        labels: ['1/1/2023', '1/2/2023', '1/3/2023', '1/4/2023', '1/5/2023', '1/6/2023', '1/7/2023', '1/8/2023', '1/9/2023', '1/10/2023', '1/11/2023', '1/12/2023', '1/13/2023']
    };
    var myDoughnutChart_2 = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: {
            responsive: false,
            maintainAspectRatio: false,
            scales: {
                y: {
                    suggestedMin: 0,
                    suggestedMax: 90,
                    fontColor: "white",
                    ticks: {
                        /*      minRotation: 90,*/
                        color: "#f5f5f5",

                    },
                    border: {
                        display: true
                    },
                    grid: {
                        color: function (context) {
                            if (context.tick.value == 0) {
                                return '#8A9A5B'
                            }

                            /* return '#000000';*/
                        },
                    }

                },
                x: {

                    ticks: {

                        color: "#f5f5f5",
                        align: 'center'
                    },

                }
            },
            plugins: {
                title: {
                    display: true,
                    position: 'top',
                    align: 'center',
                    //text: machine[index],
                    text: 'Daily OEE',
                    color: 'white',
                    padding: {
                        top: 5,
                        bottom: 10
                    },
                },
                legend: {
                    
                   
                    display: true,
                  
                    labels: {
                        color: 'white',
                        boxWidth: 45,
                        boxHeight: 2
                    }
                }
            }
        },

    });
});
