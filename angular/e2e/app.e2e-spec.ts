import { CemeterySystemTemplatePage } from './app.po';

describe('CemeterySystem App', function() {
  let page: CemeterySystemTemplatePage;

  beforeEach(() => {
    page = new CemeterySystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
