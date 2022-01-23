import './weather.css';
export default function weather({ weatherData }) {

    return (
        <div className='main'>
            <div className="top">
                <p className="header">{weatherData.WeatherText}</p>
            </div>
            <p className="temp">Temprature:{weatherData.Temperature.Metric.Value}&deg;{weatherData.Temperature.Metric.Unit} / {weatherData.Temperature.Imperial.Value}&deg;{weatherData.Temperature.Imperial.Unit} </p>
        </div>
    )

}