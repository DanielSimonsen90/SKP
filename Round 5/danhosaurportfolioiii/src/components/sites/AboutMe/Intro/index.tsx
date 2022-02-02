import { useState } from 'react'
import { useEffectOnce } from 'danholibraryrjs';
import { Project } from 'danhosaurportfolio-models';
import { useTranslate, useTranslateProgrammingLanguages } from 'providers/LanguageProvider';
import { useMe, useSetProjects } from 'providers/MeProvider';
import InfoContainer from 'components/shared/container/InfoContainer';
import LinkItem from 'components/shared/navigation/LinkItem';
import Socials from '../Socials';
import myData from 'me.json';
import './Intro.scss';

const { favoriteLanguage, favoriteProjects: favoriteProjectNames } = myData;

export default function Intro() {
    const me = useMe();
    const setProjects = useSetProjects();
    const [experienceLanguages, setExperienceLanguages] = useState(new Array<string>());
    const [favoriteProjects, setFavoriteProjects] = useState(new Array<Project | string>());

    const translate = useTranslate();
    const translateArray = useTranslate<Array<string>>();
    const translateLanguages = useTranslateProgrammingLanguages();
    const introText = translateArray("intro").map(sentence => sentence
        .replace('$name', me.name)
        .replace("$age", me.age.toString())
        .replace("$school", "Tech College")
        .replace("$experienceYears", me.codingFor.toString())
        .replace("$favoriteLanguage", favoriteLanguage)
    )

    useEffectOnce(() => {
        if (me.projects.length) return;

        setProjects()
            .then(data => {
                setExperienceLanguages(() => me.projects.map(p => p.language).reduce((result, lang) => {
                    if (!result.includes(lang) && lang !== favoriteLanguage) result.push(lang);
                    return result;
                }, new Array<string>()).sort())
                setFavoriteProjects(() => {
                    const result = new Array<Project>();
                    for (const item of data) {
                        if (favoriteProjectNames.includes(item.name)) {
                            result.push(item);
                        }
                    }
                    return result;
                })
            })
            .catch(() => {
                setExperienceLanguages([translate('unableToFetch')]);
                setFavoriteProjects([translate('unableToFetch')]);
            })
    })

    const MapExperienceLangauges = () => experienceLanguages.length ? (
        <div className="languages">
            {experienceLanguages.map(lang => <LinkItem link={`projects?language=${translateLanguages.unformat[lang] || lang}`} title={translateLanguages.format[lang] || lang} key={lang} />)}
        </div>
    ) : <p> {`${translate('otherLanguages').toLowerCase()}...`}</p>
    

    const mapSentences = (sentence: string, i: number) => {
        if (!sentence) return <br key={i} />;
        const includesExperienceLanguages = sentence.includes('$experienceLanguages');
        
        if (includesExperienceLanguages) {
            const [part] = sentence.split('$experienceLanguages');
            return (<div className='experience-languages-container' key={i}>
                <p>{part}</p>
                <MapExperienceLangauges />
            </div>);
        }
        return <p key={i}>{sentence}</p>
    }

    const FavoriteProjectList = () => favoriteProjects.length > 1 ? (
        <div className='project-container'>
            {favoriteProjects.map(v => {
                const name = typeof v === 'string' ? v : v.name;
                return [
                    <p key={`${name}-p`}>,</p>,
                    <LinkItem key={name} title={name} link={`/projects#${name}`} />
                ]
            }).flat().slice(1)}
        </div>
    ) : null;     

    return (
        <InfoContainer title='introTitle' type='flex'>
            <div className='intro-text'>
                {introText.map(mapSentences)}
                <FavoriteProjectList />
            </div>
            <Socials />
        </InfoContainer>
    )
}
