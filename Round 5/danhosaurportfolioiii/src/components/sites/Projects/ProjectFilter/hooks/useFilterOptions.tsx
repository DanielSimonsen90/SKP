import { useEffect, useMemo, useState } from "react";
import DatePicker from "react-date-picker";
import { Component } from "danholibraryrjs";
import { useLocationCollection } from "providers/MeProvider";
import { FilterData } from "../../ProjectsContent";
import Dropdown from '../Dropdown';
import FilterMenuOption from "../FilterMenuOption";
import FilterOptionCollection, { FilterOption } from "../FilterOptionCollection";
import useItemsFor from "./useItemsFor";

export type UseFitlerOptionsProps = {
    value: string,
    filter: FilterData;
    onOptionSelected(option: string): void
    onOptionValueSelected(optionValue: string): void
}

let setOptions = true;

export default function useFilterOptions(props: UseFitlerOptionsProps) {
    const { value, filter, onOptionSelected, onOptionValueSelected } = props;

    const nameOptions = useItemsFor('name');
    const languageOptions = useItemsFor('language');
    const projectTypeOptions = useItemsFor('projectType');
    const occupationOptions = useLocationCollection().map(i => i.course);

    const filterOptions = useMemo(() => {
        const dropdownData = {
            name: nameOptions,
            language: languageOptions,
            projectType: projectTypeOptions,
            occupation: occupationOptions
        }
        const dateData = ['before', 'after'];

        const filterOptions = Object.keys(dropdownData)
            .map<[string, Component]>(key => ([
                key,
                <Dropdown items={dropdownData[key]} onItemSelected={onOptionValueSelected} />
            ]))
            .concat(dateData.map(key => ([key,
                <DatePicker onClickDay={d => onOptionValueSelected(d.toDateString())} />
            ])))
            .filter(([key]) => !filter[key])
            .map<FilterOption>(([key, component]) => ({
                key, component,
                option: <FilterMenuOption onClick={onOptionSelected} key={key}
                    optionFor={key as keyof FilterData}
                />,
            }));
        return new FilterOptionCollection(filterOptions);
    }, [filter]);

    const [options, setFilterOptions] = useState(filterOptions.options);

    useEffect(() => {
        if (!value) {
            setFilterOptions(null);
            setOptions = true;
        }
        else if (!value.endsWith(':')) setFilterOptions(filterOptions.options);
    }, [value]);

    function onFocus(show: boolean) {
        if (!setOptions) return;
        setOptions = true;
        setFilterOptions(show ? filterOptions.options : null);
    }

    return { options, setFilterOptions, onFocus };
}