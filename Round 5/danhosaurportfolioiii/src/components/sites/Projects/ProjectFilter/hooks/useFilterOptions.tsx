import { useEffect, useMemo, useState } from "react";
import { Date as DanhoDate } from 'danholibraryjs';
import { Component, Dropdown, DatePicker, Button } from "danholibraryrjs";
import { useLocationCollection } from "providers/MeProvider";
import { FilterData } from "../../ProjectsContent";
import FilterMenuOption from "../FilterMenuOption";
import FilterOptionCollection, { FilterOption } from "../FilterOptionCollection";
import useItemsFor from "./useItemsFor";
import { Arrayable } from "danholibraryjs";
import { useTranslate, useTranslateFilters } from "providers/LanguageProvider";

export type UseFitlerOptionsProps = {
    value: string,
    internalValue: string,
    filter: FilterData;
    onOptionSelected(option: string): void
    onOptionValueSelected(optionValue: string): void
}

let shouldSetOptions = true;

export default function useFilterOptions(props: UseFitlerOptionsProps) {
    const { value, internalValue, filter, onOptionSelected, onOptionValueSelected } = props;

    const nameOptions = useItemsFor('name', filter);
    const languageOptions = useItemsFor('language', filter);
    const projectTypeOptions = useItemsFor('projectType', filter);
    const occupationOptions = useLocationCollection().map(i => i.course);

    const translate = useTranslate();
    const translateArray = useTranslate<Array<string>>()
    const translateFilter = useTranslateFilters();
    const translateFilterReverse = useTranslateFilters(true);

    const filterOptions = useMemo(() => {
        // console.log('Options update', {internalValue, filter});

        const dropdownData = {
            name: nameOptions,
            language: languageOptions,
            projectType: projectTypeOptions,
            occupation: occupationOptions
        }
        const dateData = ['before', 'after'];

        const filterOptions = Object.array(dropdownData)
            .map<[string, Component]>(([key, items]) => ([key,
                <Dropdown key={key} items={items} onItemSelected={value => onOptionValueSelected(value.replaceAll(' ', '_'))} />
            ]))
            .concat(dateData.map(key => ([key,
                // <DatePicker allowPastDates onChange={(d, f) => onOptionValueSelected(f)} 
                //     buttonSubmitTitle={`${translate('select')} ${translate('date')}`}
                //     dateLabelTitle={translate('date')}
                //     dateNames={translateArray('dates')}
                //     monthNames={translateArray('monthsArr')}
                // />
                <div className="datepicker">
                    <input type="date" onChange={e => {
                        console.log(e.currentTarget.value);
                        // if (!e.target.value) return;

                        // return onOptionValueSelected(new DanhoDate(new Date(e.target.value)).toString());
                    }} />
                    <Button importance="primary" crud="create" value={`${translate('select')} ${translate('date')}`} 
                        onClick={() => (
                            onOptionValueSelected(
                                new DanhoDate(new Date(
                                    document.querySelector<HTMLInputElement>('input[type=date]').value
                                )).toString()
                            )
                        )}
                    />
                </div>
            ])))
            .filter(([key]) => {
                    if (internalValue.split(':').some(v => (
                    translateFilter[key].title.includes(v) &&
                    translateFilter[key].title.includes(`${v}:`)
                ))) {
                    // console.log({ condition: "internalValue.split(':').some(v => translate[key].title.includes(v) && translate[key].title !== v)",
                    //     internalValue, translate: translateFilter, key, item: translateFilter[key]
                    // });
                    return true;
                }
                else if (internalValue.includes(':') && !filter[key]) {
                    // console.log({ condition: "!filter[key]", filter, key });
                    return true;
                }
                else if (!internalValue) return true;

                // console.log({ condition: "false", filter, key, internalValue });
                return false;
            })
            .map<FilterOption>(([key, component]) => ({
                key, component,
                option: <FilterMenuOption onClick={title => {
                    onOptionSelected(title);
                    setOptions(component);
                }} key={key}
                    optionFor={key as keyof FilterData}
                />,
            }));
        return new FilterOptionCollection(filterOptions);
    }, [filter, internalValue]);

    const [options, setOptions] = useState<Arrayable<Component>>(filterOptions.options);

    useEffect(() => {
        if (!value || !value.endsWith(':')) setOptions(filterOptions.options);
        else if (value.endsWith(':')) setOptionComponent();
    }, [value]);

    function onFocus(show: boolean) {
        if (!shouldSetOptions) return;
        else if (value.endsWith(':')) return setOptionComponent();
        shouldSetOptions = true;

        setOptions(show ? filterOptions.options : null);
    }
    function setOptionComponent() {
        const split = internalValue.split(':');
        const key = translateFilterReverse[split[split.length - 2]];

        try {
            const item = filterOptions.items.find(i => i.key === key);
            setOptions(item.component)
        }
        catch (err) {
            console.warn(err);
        }
    }

    return { options, setOptions, onFocus };
}