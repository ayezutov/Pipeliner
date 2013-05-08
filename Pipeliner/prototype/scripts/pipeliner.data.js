window.pipelinerData = {
    pipelineDescription: {
        steps: [
                {
                    id: 1,
                    name: 'Create binaries and upload them to NuGet',
                },
                {
                    id: 2,
                    name: 'Automatic unit test'
                },
                {
                    id: 3,
                    name: 'Deploy'
                },
                {
                    id: 4,
                    name: 'Manual smoke test'
                },
                {
                    id: 5,
                    name: 'Release to QA'
                }
        ]
    },
    pipelineInstances: [
        {
            id: 1,
            parameters: {
                changeSet: 40010,
            },
            steps: [
                {
                    id: 1,
                    status: 'running',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 2,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 3,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 4,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40009,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 3,
                    status: 'running',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 4,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40008,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'failed',
                    transition: {
                        status: 'stopped'
                    }
                },
                {
                    id: 3,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 4,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40007,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 3,
                    status: 'success',
                    transition: {
                        status: 'manual'
                    }
                },
                {
                    id: 4,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40006,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 3,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 4,
                    status: 'manual',
                    transition: {
                        status: 'inactive'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40005,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 3,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 4,
                    status: 'failed',
                    transition: {
                        status: 'stopped'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40004,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 3,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 4,
                    status: 'success',
                    transition: {
                        status: 'manual'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40003,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 3,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 4,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 5,
                    status: 'success',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        },
        {
            id: 2,
            parameters: {
                changeSet: 40002,
            },
            steps: [
                {
                    id: 1,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 2,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 3,
                    status: 'success',
                    transition: {
                        status: 'success'
                    }
                },
                {
                    id: 4,
                    status: 'success',
                    transition: {
                        status: 'manual'
                    }
                },
                {
                    id: 5,
                    status: 'pending',
                    transition: {
                        status: 'inactive'
                    }
                }
            ]
        }
    ]
}