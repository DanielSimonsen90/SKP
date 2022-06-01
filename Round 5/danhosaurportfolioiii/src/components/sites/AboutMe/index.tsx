import Portrait from 'components/shared/images/Portrait'
import Intro from './Intro'
import SpareTime from './SpareTime'
import './AboutMe.scss'

export default function AboutMe() {
    return (
        <section className="about-me-page">
            <Intro />
            <Portrait uwuVerySecret={true} />
            <SpareTime />
        </section>
    )
}
