import Portrait from 'components/shared/images/Portrait'
import Intro from './Intro'
import SpareTime from './SpareTime'
import './AboutMe.scss'

export default function AboutMe() {
    return (
        <div id="about-me-page">
            <Intro />
            <Portrait uwuVerySecret={true} />
            <SpareTime />
        </div>
    )
}
