import { render, screen } from '@testing-library/react';
import LayoutComponent from '../Component/LayoutComponent';

test('renders check the title of the sites', () => {
  render(<LayoutComponent />);
  const linkElement = screen.getByText(/movie center/i);
  expect(linkElement).toBeInTheDocument();
});

