import { useState } from 'react';

const Formats = {
	bold: /(\*{2})(?<content>[\w|\d|\s]+)(\1)/,
	underline: /(_{2})(?<content>.+)(\1)/,
	link: /\[(?<content>.+)\]\((?<link>https?:\/\/(w{3})?\w+\.\w+\/?)\)/,
	italic: /([*|_]{1})(?<content>.+)(\1)/,
};

type RegexArray = RegExpExecArray & {
	groups: {
		content: string;
		link?: string;
	};
};

export default function App() {
	const [message, setMessage] = useState('');
	const [messages, setMessages] = useState(new Array<JSX.Element>());
	const [messageCount, setMessageCount] = useState(0);

	// useEffect(() => {
	//   setMessages(() => [
	//     <p>*italic*</p>,
	//     <p>_italic_</p>,
	//     <p>**bold**</p>,
	//     <p>__underline__</p>,
	//     <p>[Cool testing](https://google.com)</p>,
	//   ])
	// }, [])

	function sendMessage() {
		const formatArray = Object.keys(Formats).map(k => [
			k,
			Formats[k as keyof typeof Formats],
		]) as Array<[string, RegExp]>;
		const content = message.split(' ').map((word, i) => {
			for (const [type, regex] of formatArray) {
				if (!regex.test(word)) continue;

				const regexResult = regex.exec(word) as RegexArray;
				const {
					groups: { content, link },
				} = regexResult;

				console.log({ type, regex, word, content, link, regexResult });

				switch (type) {
					case 'italic':
						return <i key={i}>{content} </i>;
					case 'bold':
						return <b key={i}>{content} </b>;
					case 'underline':
						return <u key={i}>{content} </u>;
					case 'link':
						return (
							<a key={i} href={link}>
								{content}{' '}
							</a>
						);
				}
			}
			return `${word} `;
		});

		setMessages(arr => [...arr, <p key={messageCount}>{content}</p>]);
		setMessage('');
		setMessageCount(c => c + 1);
	}

	return (
		<div
			style={{
				height: '100vh',
				display: 'flex',
				flexDirection: 'column',
				justifyContent: 'space-between',
			}}>
			<div>{messages}</div>
			<input
				type='text'
				value={message}
				onChange={e => setMessage(e.target.value)}
				onKeyPress={e => {
					if (e.key === 'Enter') sendMessage();
				}}
			/>
		</div>
	);
}
