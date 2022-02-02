import Portrait from 'components/shared/images/Portrait'
import Intro from './Intro'
import SpareTime from './SpareTime'
import './AboutMe.scss'

export default function AboutMe() {
    return (
        <main id="about-me-page">
            <Intro />
            <Portrait uwuVerySecret={true} />
            <SpareTime />
        </main>
    )
}
