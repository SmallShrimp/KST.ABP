export const environment = {
  production: true,
  hmr: false,
  application: {
    name: 'Organizations',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44323',
    clientId: 'Organizations_ConsoleTestApp',
    dummyClientSecret: '1q2w3e*',
    scope: 'Organizations',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44350',
    },
  },
  localization: {
    defaultResourceName: 'Organizations',
  },
};
