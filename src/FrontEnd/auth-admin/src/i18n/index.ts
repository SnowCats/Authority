import { Locales } from './locales';

import cn from "./cn";
import en from './en';

export const messages = {
    [Locales.CN]: cn,
    [Locales.EN]: en
};

export const defaultLocale = Locales.CN;