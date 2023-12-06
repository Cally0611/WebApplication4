
//This part 
var date = new Date();

var numeric = { day: 'numeric', month: 'numeric' };
console.log(date.toLocaleDateString('en-GB', numeric));
//Till here

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

const machine = [];

const denoprofile = [];

function getItems() {
    fetch('api/StopReasons/DailyOEE')
        .then(response => response.json())
        .then(data => _displayItems(data))
    
        .catch(error => console.error('Unable to get items.', error));
}

function getItemsByJob() {
    fetch('api/StopReasons/ByJob')
        .then(response => response.json())
        .then(data => _displayItemsbyJob(data))

        .catch(error => console.error('Unable to get items.', error));
}

function _displayItemsbyJob(data) {
    console.log(data);
    $.each(data, function (index, value) {
        //console.log(parseFloat(value.OEE).toFixed(2));
        document.getElementById('oeejobID' + index).innerHTML = 'OEE Total ' + parseFloat(value.OEE).toFixed(2) + '%';
        //console.log(index + "-" + value);
    });
}

//This part
function _displayItems(data) {
    //console.log(data);
    $.each(data, function (index, value) {
       // console.log(value);
        var chartlabel = [];
        var oeevalue = [];
        var oeepercentage = [];
        //console.log(index + ": " + value);
        $.each(value, function (index, value) {
            //console.log(value.Availability);
            //console.log(index + ": " + value);
            //console.log(value.Target_Date);
            var date2 = new Date(value.Target_Date);
            var newdate = date2.toLocaleDateString('en-GB', numeric);
            var datetoenter = newdate;
           
            var oeetoenter = value.OEE;
            var oeeavgtoenter = value.OEEAveragePercentage;
            chartlabel.push(datetoenter.split('T')[0]);
            if (oeetoenter == null) {
                oeetoenter = 0;
            }
         
            oeevalue.push(oeetoenter);
            oeepercentage.push(oeeavgtoenter);
           
        });
         //console.log(chartlabel);
         //   console.log(oeevalue);
        var chartnum = ("barchartC" + index).toString();
        console.log(chartnum);

        const ctx = document.getElementById(chartnum);

        ctx.classList.add('insidecanvas');
        var background_1 = gradientcolor(ctx.getContext("2d"));
        //console.log('ChartNum' + ctx);
        var data = {
            datasets: [
                {
                    type: 'bar',
                    barThickness: 2,
                    label: 'OEE',
                    data: oeevalue,
                    backgroundColor: [
                        background_1
                    ],
                    datalabels: {
                        align: 'center',
                        anchor: 'center',
                        color: 'white',
                        font: {
                            weight: 'bold'
                        },
                        formatter: Math.round,
                        labels: {
                            title: null
                        }

                    },
                   // pointBorderColor: 'rgb(0, 0, 0)'
                },
                {
                    type: 'line',
                  
                    label: 'Average OEE',
                    data: oeepercentage,
                    backgroundColor: [
                        '#00FFFF'
                    ],
                    radius: 0,
                    tension: 0.1,
                    borderColor: ' #00FFFF',
                    borderWidth: 2,
                    datalabels: {
                        align: 'center',
                        anchor: 'center',
                        color: 'white',
                        font: {
                            weight: 'bold'
                        },
                        formatter: Math.round,
                        labels: {
                            title: null
                        }

                    },
                    //pointBorderColor: 'rgb(0, 0, 0)'
                }




            ],
            labels: chartlabel
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
                        //ticks: {
                        //          minRotation: 90,
                        //    color: "#f5f5f5",

                        //},
                        border: {
                            display: true
                        },
                        grid: {
                            color: function (context) {
                                if (context.tick.value == 0) {
                                    return '#8A9A5B'
                                }

                                // return '#000000';
                            },
                        }

                    },
                    x: {
                        fontColor: "white",
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
                        text: machine[index],
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
   
}

function getItemsOEEByShift() {
    fetch('api/StopReasons/OEEByShift')
        .then(response => response.json())
        .then(data => _displayOEEbyShift(data))

        .catch(error => console.error('Unable to get items.', error));
}


function _displayOEEbyShift(data) {
    console.log(data);
}
